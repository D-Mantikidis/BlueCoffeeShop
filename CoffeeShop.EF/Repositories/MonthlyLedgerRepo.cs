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
    internal class MonthlyLedgerRepo : IEntityRepo<MonthlyLedger>
    {
        private readonly CoffeeShopContext _context;
        public MonthlyLedgerRepo()
        {
            _context = new CoffeeShopContext();
        }
        public async Task Create(MonthlyLedger entity)
        {
            _context.MonthlyLedgers.Add(entity);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<MonthlyLedger> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MonthlyLedger>> GetAllAsync()
        {
            return await _context.MonthlyLedgers.ToListAsync();
        }

        public MonthlyLedger? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MonthlyLedger?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id, MonthlyLedger entity)
        {
            var foundMonthlyLedger = await _context.MonthlyLedgers.SingleOrDefaultAsync(ml => ml.Id == id);
            if (foundMonthlyLedger == null)
                return;
            foundMonthlyLedger.Date = entity.Date;
            foundMonthlyLedger.Expenses = entity.Expenses;
            foundMonthlyLedger.Income = entity.Income;
            foundMonthlyLedger.Total = entity.Total;

        }
    }
}
