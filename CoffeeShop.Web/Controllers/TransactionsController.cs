#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeShop.EF.Context;
using CoffeeShop.Model;
using CoffeeShop.EF.Repositories;
using CoffeeShop.Web.Models;
using CoffeeShop.Model.Handlers;

namespace CoffeeShop.Web.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly CoffeeShopContext _context;
        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly IEntityRepo<Customer> _customerRepo;
        private readonly IEntityRepo<Employee> _employeeRepo;
        private readonly IEntityRepo<TransactionLine> _transactionLineRepo;
        private readonly IEntityRepo<Product> _productRepo;
        private EnumsHandler _enumsHandler;
        private TransactionHandler _transactionHandler;
        private TransactionLineHandler _transactionLineHandler;




        public TransactionsController(IEntityRepo<Transaction> transactionRepo,
            IEntityRepo<Employee> employeeRepo, IEntityRepo<Customer> customerRepo,
            IEntityRepo<TransactionLine> transactionLineRepo, IEntityRepo<Product> productRepo)
        {
            _transactionRepo = transactionRepo;
            _employeeRepo = employeeRepo;
            _customerRepo = customerRepo;
            _transactionLineRepo = transactionLineRepo;
            _productRepo = productRepo;
            _enumsHandler = new EnumsHandler();
            _transactionHandler = new TransactionHandler();
            _transactionLineHandler = new TransactionLineHandler();

        }
        public async Task<IActionResult> TransactionLineIndex()
        {

            return RedirectToAction("Index", "Customers");
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            return View(await _transactionRepo.GetAllAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var a = await _productRepo.GetAllAsync();

            ViewData["ProductID"] = a;
            if (id == null)
            {
                return NotFound();
            }
            var transaction = await _transactionRepo.GetByIdAsync(id.Value);
            if (transaction == null)
            {
                return NotFound();
            }
            var viewModel = new TransactionDetailViewModel
            {
                Customer = transaction.Customer.Description,
                Employee = transaction.Employee.Surname,
                Date = transaction.Date,
                Id = transaction.Id,
                PaymentMethod = transaction.PaymentMethod,
                TotalPrice = transaction.TotalPrice,

            };
            foreach (var transactions in transaction.TransactionLines)
            {
                var transactionLineDetailViewModel = new TransactionLineDetailViewModel
                {
                    Discount = transactions.Discount,
                    Quantity = transactions.Qty,
                    Price = transactions.Price,
                    ProductID = transactions.ProductID,
                    TotalPrice = transactions.TotalPrice,
                    ID = transactions.Id

                };
                viewModel.TransactionLines.Add(transactionLineDetailViewModel);
            }
            var paymentMethodList = _transactionHandler.CheckPaymentMethod(transaction, 50);
            ViewData["PaymentMethod"] = new SelectList(paymentMethodList, "ID", "Name");
            return View(viewModel);
        }

        // GET: Transactions/Create
        public async Task<IActionResult> Create()
        {
            var a = await _customerRepo.GetAllAsync();
            var b = await _employeeRepo.GetAllAsync();
            ViewData["CustomerID"] = new SelectList(a, "Id", "Description");
            ViewData["EmployeeID"] = new SelectList(b, "Id", "Name");

            ViewData["PaymentTypeList"] = new SelectList(_enumsHandler.GetPaymentEnumList(), "ID", "Name");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,CustomerID,EmployeeID,PaymentMethod")] TransactionCreateViewModel transactionCreateViewModel)
        {
            if (ModelState.IsValid)
            {

                var newTransaction = new Transaction
                {

                    Date = DateTime.Now,
                    CustomerID = transactionCreateViewModel.CustomerID,
                    EmployeeID = transactionCreateViewModel.EmployeeID,
                    //TransactionLines = new Transaction().TransactionLines,
                    //TotalPrice = transactionCreateViewModel.TotalPrice,
                    PaymentMethod = transactionCreateViewModel.PaymentMethod,
                    //Customer=null,
                    //Employee=null
                };
                await _transactionRepo.Create(newTransaction);
                return RedirectToAction(nameof(Index));
            }

            return View(transactionCreateViewModel);
        }

        public async Task<IActionResult> AddTransactionLine(int? id)
        {
            var a = await _productRepo.GetAllAsync();
            ViewData["ProductList"] = new SelectList(a, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTransactionLine(int? id, [Bind("Quantity,ProductID,Discount")] TransactionLineViewModel transactionLineViewModel)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var transaction = await _transactionRepo.GetByIdAsync(id.Value);

                var newTransactionLine = new TransactionLine
                {
                    Discount = transactionLineViewModel.Discount,
                    Qty = transactionLineViewModel.Quantity,
                    //Price = transactionLineViewModel.,
                    ProductID = transactionLineViewModel.ProductID,
                    //TotalPrice = transactionLineViewModel.TotalPrice,
                    TransactionID = id.Value

                };

                var product = await _productRepo.GetByIdAsync(newTransactionLine.ProductID);
                newTransactionLine.Price = product.Price;
                newTransactionLine.TotalPrice = _transactionLineHandler.GetTotalPrice(newTransactionLine);

                await _transactionLineRepo.Create(newTransactionLine);
                transaction.TotalPrice = _transactionHandler.GetTotalPrice(transaction);
                _transactionHandler.ApplyDiscount(transaction, 0.15f, 10);
                await _transactionRepo.Update(id.Value, transaction);

                return RedirectToAction(nameof(Details), new { id });
            }

            return View(transactionLineViewModel);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "Id", "Code", transaction.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "Id", "Name", transaction.EmployeeID);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Date,CustomerID,EmployeeID,TotalPrice,PaymentMethod,Id")] Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "Id", "Code", transaction.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "Id", "Name", transaction.EmployeeID);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Customer)
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        private async Task<IActionResult> CheckPayMethod(int id)
        {
            var currentTransaction = await _transactionRepo.GetByIdAsync(id);
            if (currentTransaction == null)
                return BadRequest();
            var paymentList = _transactionHandler.CheckPaymentMethod(currentTransaction, 50);
            ViewData["ProductTypeList"] = new SelectList(paymentList, "Id", "Code");
            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
