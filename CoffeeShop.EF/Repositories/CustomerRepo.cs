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
    public class CustomerRepo : IEntityRepo<Customer>
    {
        private readonly CoffeeShopContext _context;

        public CustomerRepo(CoffeeShopContext context)
        {
            _context = context;
        }

        public async Task Create(Customer entity)
        {
            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var foundCustomer = _context.Customers.SingleOrDefault(customer => customer.Id == id);
            if (foundCustomer != null)
                return;
            _context.Customers.Remove(foundCustomer);
            await _context.SaveChangesAsync();
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public Customer? GetById(int id)
        {
            return _context.Customers.Where(customer => customer.Id == id).SingleOrDefault();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers.SingleOrDefaultAsync(customer => customer.Id == id);
        }

        public async Task Update(int id, Customer entity)
        {
            var foundCustomer = _context.Customers.SingleOrDefault(customer => customer.Id == id);
            if (foundCustomer is null)
                return;
            foundCustomer.Code = entity.Code;
            foundCustomer.Description = entity.Description;
            await _context.SaveChangesAsync();
        }
    }
}