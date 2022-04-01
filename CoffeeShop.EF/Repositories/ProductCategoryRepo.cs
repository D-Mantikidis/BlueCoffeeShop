using CoffeeShop.EF.Context;
using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EF.Repositories
{
    public class ProductCategoryRepo : IEntityRepo<ProductCategory>
    {
        public async Task Create(ProductCategory entity)
        {
            using var context = new CoffeeShopContext();
            context.ProductCategories.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var context = new CoffeeShopContext();
            var foundProductCategory = context.ProductCategories.SingleOrDefault(product => product.Id == id);
            if (foundProductCategory != null)
                return;
            context.ProductCategories.Remove(foundProductCategory);
            await context.SaveChangesAsync();
        }

        public List<ProductCategory> GetAll()
        {
            using var context = new CoffeeShopContext();
            return context.ProductCategories.ToList();
        }

        public Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ProductCategory? GetById(int id)
        {
            using var context = new CoffeeShopContext();
            return context.ProductCategories.Where(product => product.Id == id).SingleOrDefault();
        }

        public Task<ProductCategory?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id, ProductCategory entity)
        {
            using var context = new CoffeeShopContext();
            var foundProductCategory = context.ProductCategories.SingleOrDefault(product => product.Id == id);
            if (foundProductCategory is null)
                return;
            foundProductCategory.Code = entity.Code;
            foundProductCategory.Description = entity.Description;
            foundProductCategory.ProductType = entity.ProductType;
            await context.SaveChangesAsync();
        }
    }
}