﻿using CoffeeShop.EF.Context;
using CoffeeShop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EF.Repositories
{
    public class ProductRepo : IEntityRepo<Product>
    {
        private readonly CoffeeShopContext _context;

        public ProductRepo(CoffeeShopContext context)
        {
            _context = context;
        }
        public async Task Create(Product entity)
        {
            //using var context = new CoffeeShopContext();
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            //using var context = new CoffeeShopContext();
            var foundProduct = _context.Products.SingleOrDefault(product => product.Id == id);
            if (foundProduct != null)
                return;
            _context.Products.Remove(foundProduct);
            await _context.SaveChangesAsync();
        }

        public List<Product> GetAll()
        {
            //using var context = new CoffeeShopContext();
            return _context.Products.ToList();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync(); ;
        }

        public Product? GetById(int id)
        {
            //using var context = new CoffeeShopContext();
            return _context.Products.Where(product => product.Id == id).SingleOrDefault();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(customer => customer.Id == id)
        }

        public async Task Update(int id, Product entity)
        {
            using var context = new CoffeeShopContext();
            var foundProduct = context.Products.SingleOrDefault(product => product.Id == id);
            if (foundProduct is null)
                return;
            foundProduct.Code = entity.Code;
            foundProduct.Description = entity.Description;
            foundProduct.ProductCategoryID = entity.ProductCategoryID;
            foundProduct.Price = entity.Price;
            foundProduct.Cost = entity.Cost;
            await context.SaveChangesAsync();
        }
    }
}