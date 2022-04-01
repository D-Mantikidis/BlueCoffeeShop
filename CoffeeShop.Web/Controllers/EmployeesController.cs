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

namespace CoffeeShop.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly CoffeeShopContext _context;
        private readonly IEntityRepo<Employee> _employeeRepo;

        public EmployeesController(IEntityRepo<Employee> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _employeeRepo.GetAllAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepo.GetByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeViewModel = new EmployeeListViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                SalaryPerMonth = employee.SalaryPerMonth,
                EmployeeType = employee.EmployeeType
            };

            return View(employeeViewModel);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,SalaryPerMonth,EmployeeType")] EmployeeCreateViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = new Employee()
                {
                    Name = employeeViewModel.Name,
                    Surname = employeeViewModel.Surname,
                    SalaryPerMonth = employeeViewModel.SalaryPerMonth,
                    EmployeeType = employeeViewModel.EmployeeType
                };
            }
            return View(employeeViewModel);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepo.GetByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            var updateEmployee = new EmployeeUpdateViewModel
            {
                Name = employee.Name,
                Surname = employee.Surname,
                SalaryPerMonth = employee.SalaryPerMonth,
                EmployeeType = employee.EmployeeType
            };
            return View(updateEmployee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Surname,SalaryPerMonth,EmployeeType,Id")] EmployeeUpdateViewModel employeeViewModel)
        {
            if (id != employeeViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentEmployee = await _employeeRepo.GetByIdAsync(id);
                if (currentEmployee == null)
                    return BadRequest();
                currentEmployee.Name = employeeViewModel.Name;
                currentEmployee.Surname = employeeViewModel.Surname;
                currentEmployee.SalaryPerMonth = employeeViewModel.SalaryPerMonth;
                currentEmployee.EmployeeType = employeeViewModel.EmployeeType;
                _employeeRepo.Update(id, currentEmployee);
                return RedirectToAction(nameof(Index));
            }
            return View(employeeViewModel);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepo.GetByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            var employeeViewModel = new EmployeeDeleteViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                SalaryPerMonth = employee.SalaryPerMonth,
                EmployeeType = employee.EmployeeType
            };
            return View(employeeViewModel);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool EmployeeExists(int id)
        //{
        //    return _context.Employees.Any(e => e.Id == id);
        //}
    }
}
