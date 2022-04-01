using CoffeeShop.EF.Context;
using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EF.Repositories
{
    public class CustomerRepo : IEntityRepo<Customer>
    {
        public async Task Create(Customer entity)
        {
            using var context = new CoffeeShopContext();
            context.Customers.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var context = new CoffeeShopContext();
            var foundCustomer = context.Customers.SingleOrDefault(customer => customer.Id == id);
            if (foundCustomer != null)
                return;
            context.Customers.Remove(foundCustomer);
            await context.SaveChangesAsync();
        }

        public List<Customer> GetAll()
        {
            using var context = new CoffeeShopContext();
            return context.Customers.ToList();
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Customer? GetById(int id)
        {
            using var context = new CoffeeShopContext();
            return context.Customers.Where(customer => customer.Id == id).SingleOrDefault();
        }

        public Task<Customer?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id, Customer entity)
        {
            using var context = new CoffeeShopContext();
            var foundCustomer = context.Customers.SingleOrDefault(customer => customer.Id == id);
            if (foundCustomer is null)
                return;
            foundCustomer.Code = entity.Code;
            foundCustomer.Description = entity.Description;
            await context.SaveChangesAsync();
        }
    }
}