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
using System.Collections;
using CoffeeShop.Model.Handlers;

namespace CoffeeShop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly CoffeeShopContext _context;
        private readonly IEntityRepo<Product> _productRepo;
        private readonly IEntityRepo<ProductCategory> _productCategoryRepo;
        

        public ProductsController(IEntityRepo<Product> productRepo, IEntityRepo<ProductCategory> productCategoryRepo)
        {
            _productRepo = productRepo;
            _productCategoryRepo = productCategoryRepo;
           
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var a = await _productCategoryRepo.GetAllAsync();
            
            ViewData["ProductCategoryID"] = a;
            
    
            
            return View(await _productRepo.GetAllAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepo.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            var viewModel = new ProductListViewModel()
            {
                Id = product.Id,
                Price = product.Price,
                Code = product.Code,
                Cost = product.Cost,
                Description = product.Description,
                ProductCategory = product.ProductCategory.Description
                
            };

            return View(viewModel);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            var a = await _productCategoryRepo.GetAllAsync();
            ViewData["ProductCategoryList"] = new SelectList( a, "Id", "Description");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Price,Cost,Code,Description,ProductCategoryID")] ProductCreateViewModel productCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var newProduct = new Product()
                {
                    ProductCategoryID = Int32.Parse(productCreateViewModel.ProductCategoryID),
                    Price = productCreateViewModel.Price,
                    Cost = productCreateViewModel.Cost,
                    Code = productCreateViewModel.Code,
                    Description = productCreateViewModel.Description,


                };
                
                await _productRepo.Create(newProduct);
                return RedirectToAction(nameof(Index));
            }
            
            return View(productCreateViewModel);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepo.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            var updateProduct = new ProductUpdateViewModel()
            {
                Code = product.Code,
                Description= product.Description,
                Cost = product.Cost,
                Id = product.Id,
                Price= product.Price,
            };

            var a = await _productCategoryRepo.GetAllAsync();
            ViewData["ProductCategoryList"] = new SelectList(a, "Id", "Description");
            return View(updateProduct);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductCategoryID,Price,Cost,Code,Description,Id")] ProductUpdateViewModel productUpdateViewModel)
        {
            if (id != productUpdateViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentProduct = await _productRepo.GetByIdAsync(id);
                if (currentProduct == null)
                    return BadRequest();
                currentProduct.Price = productUpdateViewModel.Price;
                currentProduct.Description = productUpdateViewModel.Description;
                currentProduct.Cost = productUpdateViewModel.Cost;
                currentProduct.Id = productUpdateViewModel.Id;  
                currentProduct.Code = productUpdateViewModel.Code;
                currentProduct.ProductCategoryID = productUpdateViewModel.ProductCategoryID;
                await _productRepo.Update(id, currentProduct);
                return RedirectToAction(nameof(Index));
            }
            
            return View(productUpdateViewModel);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepo.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            var viewModel = new ProductDeleteViewModel()
            {
                Code = product.Code,
                Price = product.Price,
                Cost = product.Cost,
                Id = product.Id,
                Description = product.Description,
                ProductCategory = product.ProductCategory.Description
            };

            return View(viewModel);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
