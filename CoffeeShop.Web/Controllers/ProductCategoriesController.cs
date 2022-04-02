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
using CoffeeShop.Model.Handlers;

namespace CoffeeShop.Web.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private readonly CoffeeShopContext _context;
        private readonly IEntityRepo<ProductCategory> _productCategoryRepo;
        private EnumsHandler _enumsHandler;

        public ProductCategoriesController(IEntityRepo<ProductCategory> productCategory)
        {
            _productCategoryRepo = productCategory;
            _enumsHandler = new EnumsHandler();
        }

        // GET: ProductCategories
        public async Task<IActionResult> Index()
        {
            return View(await _productCategoryRepo.GetAllAsync());
        }

        // GET: ProductCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _productCategoryRepo.GetByIdAsync(id.Value);
                
            if (productCategory == null)
            {
                return NotFound();
            }
            var viewModel = new ProductCategoryListViewModel
            {
                Id=productCategory.Id,
                ProductType = productCategory.ProductType,
                Code=productCategory.Code,
                Description=productCategory.Description

            };
            return View(viewModel);
        }

        // GET: ProductCategories/Create
        public IActionResult Create()
        {
            ViewData["ProductCategoryList"] = new SelectList(_enumsHandler.GetProductTypeEnumList(), "ID", "Name");
            return View();
        }

        // POST: ProductCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductType,Code,Description")] ProductCategoryCreateViewModel productCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var newProductCategory = new ProductCategory()
                {
                    ProductType = productCategoryViewModel.ProductType,
                    Code = productCategoryViewModel.Code,
                    Description = productCategoryViewModel.Description

                };
                await _productCategoryRepo.Create(newProductCategory);
                return RedirectToAction(nameof(Index));
            }
            return View(productCategoryViewModel);
        }

        // GET: ProductCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _productCategoryRepo.GetByIdAsync(id.Value);
            if (productCategory == null)
            {
                return NotFound();
            }
            var updateProductCategory = new ProductCategoryUpdateViewModel
            {
                ProductType = productCategory.ProductType,
                Code = productCategory.Code,
                Description = productCategory.Description
            };
            return View(updateProductCategory);
        }

        // POST: ProductCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductType,Code,Description,Id")] ProductCategoryUpdateViewModel productCategoryUpdateViewModel)
        {
            if (id != productCategoryUpdateViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentProductCategory = await _productCategoryRepo.GetByIdAsync(id);
                if (currentProductCategory == null)
                    return BadRequest();
                currentProductCategory.Code = productCategoryUpdateViewModel.Code;
                currentProductCategory.Description = productCategoryUpdateViewModel.Description;
                await _productCategoryRepo.Update(id, currentProductCategory);

                return RedirectToAction(nameof(Index));
            }
            return View(productCategoryUpdateViewModel);
        }

        // GET: ProductCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _productCategoryRepo.GetByIdAsync(id.Value);
               
            if (productCategory == null)
            {
                return NotFound();
            }
            var viewModel = new ProductCategoryDeleteViewModel
            {
                Id = productCategory.Id,
                ProductType = productCategory.ProductType,
                Code = productCategory.Code,
                Description = productCategory.Description

            };

            return View(viewModel);
        }

        // POST: ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
            await _productCategoryRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCategoryExists(int id)
        {
            return _context.ProductCategories.Any(e => e.Id == id);
        }
    }
}
