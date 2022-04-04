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
    public class TransactionLineRepo : IEntityRepo<TransactionLine>
    {
        private readonly CoffeeShopContext _context;
        public TransactionLineRepo(CoffeeShopContext context)
        {
            _context = context;

        }
        public async Task Create(TransactionLine entity)
        {
           
            _context.TransactionLines.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            
            var foundTransactionLine = await _context.TransactionLines.SingleOrDefaultAsync(transactionLine => transactionLine.Id == id);
            if (foundTransactionLine == null)
                return;
            _context.TransactionLines.Remove(foundTransactionLine);
            await _context.SaveChangesAsync();
        }

        public List<TransactionLine> GetAll()
        {
            
            return _context.TransactionLines.ToList();
        }

        public async Task<IEnumerable<TransactionLine>> GetAllAsync()
        {
            return await _context.TransactionLines.Include(transactionLine => transactionLine.Product).Include(transactionLine => transactionLine.Transaction).ToListAsync();
        }

        public TransactionLine? GetById(int id)
        {
            
            return _context.TransactionLines.Where(transactionLine => transactionLine.Id == id).SingleOrDefault();
        }

        public async Task<TransactionLine?> GetByIdAsync(int id)
        {
            return await  _context.TransactionLines.Include(x=>x.Product).Include(x => x.Transaction).SingleOrDefaultAsync(transactionLine => transactionLine.Id == id);
        }
    

        public async Task Update(int id, TransactionLine entity)
        {
            
            var foundTransactionLine = await _context.TransactionLines.SingleOrDefaultAsync(transactionLine => transactionLine.Id == id);
            if (foundTransactionLine is null)
                return;
            foundTransactionLine.Qty = entity.Qty;
            foundTransactionLine.Price = entity.Price;
            foundTransactionLine.Discount = entity.Discount;
            foundTransactionLine.TotalPrice = entity.TotalPrice;
            foundTransactionLine.ProductID = entity.ProductID;
            foundTransactionLine.TransactionID = entity.TransactionID;
            await _context.SaveChangesAsync();
        }
    }
}