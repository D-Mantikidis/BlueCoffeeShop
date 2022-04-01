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

namespace CoffeeShop.Web
{
    public class CustomersController : Controller
    {
        private readonly CoffeeShopContext _context;
        private readonly IEntityRepo<Customer> _customerRepo;

        public CustomersController(IEntityRepo<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _customerRepo.GetAllAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepo.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerListViewModel
            {
                Id = customer.Id,
                Code = customer.Code,
                Description = customer.Description
            };

            return View(viewModel);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Description")] CustomerCreateViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                var newCustomer = new Customer()
                {
                    Code = customerViewModel.Code,
                    Description = customerViewModel.Description

                };

                await _customerRepo.Create(newCustomer);
                return RedirectToAction(nameof(Index));
            }
            return View(customerViewModel);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepo.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            var updateCustomer = new CustomerUpdateViewModel
            {
                Code = customer.Code,
                Description = customer.Description
            };

            return View(updateCustomer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Code,Description,Id")] CustomerUpdateViewModel customerViewModel)
        {
            if (id != customerViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentCustomer = await _customerRepo.GetByIdAsync(id);
                if (currentCustomer == null)
                    return BadRequest();
                currentCustomer.Code = customerViewModel.Code;
                currentCustomer.Description = customerViewModel.Description;
                _customerRepo.Update(id, currentCustomer);
                return RedirectToAction(nameof(Index));
            }
            return View(customerViewModel);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepo.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerDeleteViewModel
            {
                Code = customer.Code,
                Id = customer.Id,
                Description = customer.Description
            };

            return View(viewModel);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _customerRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
