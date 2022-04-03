using CoffeeShop.EF.Context;
using CoffeeShop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EF.Repositories
{
    public class TransactionRepo : IEntityRepo<Transaction>
    {
        private readonly CoffeeShopContext _context;
        public TransactionRepo(CoffeeShopContext context)
        {
            _context = context;

        }
        public async Task Create(Transaction entity)
        {
           
            _context.Transactions.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            
            var foundTransaction = _context.Transactions.SingleOrDefault(transaction => transaction.Id == id);
            if (foundTransaction == null)
                return;
            _context.Transactions.Remove(foundTransaction);
            await _context.SaveChangesAsync();
        }

        public List<Transaction> GetAll()
        {
            
            return _context.Transactions.Include(transaction => transaction.TransactionLines).ToList();
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {//redoit 
            return await _context.Transactions.Include(transaction => transaction.TransactionLines).Include(transaction => transaction.Customer).Include(transaction => transaction.Employee).ToListAsync();
        }

        public Transaction? GetById(int id)
        {
            
            return _context.Transactions.Where(transaction => transaction.Id == id).SingleOrDefault();
        }

        public async Task<Transaction?> GetByIdAsync(int id)
        {
            return await  _context.Transactions.Include(x=> x.TransactionLines).Include(x=>x.Customer).Include(x => x.Employee).SingleOrDefaultAsync(transaction => transaction.Id == id);
        }
    

        public async Task Update(int id, Transaction entity)
        {
            
            var foundTransaction = _context.Transactions.Include(transaction => transaction.TransactionLines).SingleOrDefault(transaction => transaction.Id == id);
            if (foundTransaction is null)
                return;
            foundTransaction.Date = entity.Date;
            foundTransaction.CustomerID = entity.CustomerID;
            foundTransaction.EmployeeID = entity.EmployeeID;
            foundTransaction.PaymentMethod = entity.PaymentMethod;
            foundTransaction.TotalPrice = entity.TotalPrice;
            foundTransaction.TransactionLines = entity.TransactionLines;
            await _context.SaveChangesAsync();
        }
    }
}