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
        public async Task Create(Transaction entity)
        {
            using var context = new CoffeeShopContext();
            context.Transactions.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var context = new CoffeeShopContext();
            var foundTransaction = context.Transactions.SingleOrDefault(transaction => transaction.Id == id);
            if (foundTransaction != null)
                return;
            context.Transactions.Remove(foundTransaction);
            await context.SaveChangesAsync();
        }

        public List<Transaction> GetAll()
        {
            using var context = new CoffeeShopContext();
            return context.Transactions.Include(transaction => transaction.TransactionLines).ToList();
        }

        public Transaction? GetById(int id)
        {
            using var context = new CoffeeShopContext();
            return context.Transactions.Where(transaction => transaction.Id == id).SingleOrDefault();
        }

        public async Task Update(int id, Transaction entity)
        {
            using var context = new CoffeeShopContext();
            var foundTransaction = context.Transactions.Include(transaction => transaction.TransactionLines).SingleOrDefault(transaction => transaction.Id == id);
            if (foundTransaction is null)
                return;
            foundTransaction.Date = entity.Date;
            foundTransaction.CustomerID = entity.CustomerID;
            foundTransaction.EmployeeID = entity.EmployeeID;
            foundTransaction.PaymentMethod = entity.PaymentMethod;
            foundTransaction.TotalPrice = entity.TotalPrice;
            foundTransaction.TransactionLines = entity.TransactionLines;
            await context.SaveChangesAsync();
        }
    }
}