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
    public class ProductCategoryRepo : IEntityRepo<ProductCategory>
    {
        private readonly CoffeeShopContext _context;

        public ProductCategoryRepo(CoffeeShopContext context)
        {
            _context = context;
        }

        public async Task Create(ProductCategory entity)
        {
            _context.ProductCategories.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var foundProductCategory = await _context.ProductCategories.SingleOrDefaultAsync(product => product.Id == id);
            if (foundProductCategory == null)
                return;
            _context.ProductCategories.Remove(foundProductCategory);
            await _context.SaveChangesAsync();
        }

        public List<ProductCategory> GetAll()
        {
            return _context.ProductCategories.ToList();
        }

        public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public ProductCategory? GetById(int id)
        {
            return _context.ProductCategories.Where(product => product.Id == id).SingleOrDefault();
        }

        public async Task<ProductCategory?> GetByIdAsync(int id)
        {
            return await _context.ProductCategories.Where(product => product.Id == id).SingleOrDefaultAsync();
        }

        public async Task Update(int id, ProductCategory entity)
        {
            var foundProductCategory = await _context.ProductCategories.SingleOrDefaultAsync(product => product.Id == id);
            if (foundProductCategory is null)
                return;
            foundProductCategory.Code = entity.Code;
            foundProductCategory.Description = entity.Description;
            foundProductCategory.ProductType = entity.ProductType;
            await _context.SaveChangesAsync();
        }
    }
}