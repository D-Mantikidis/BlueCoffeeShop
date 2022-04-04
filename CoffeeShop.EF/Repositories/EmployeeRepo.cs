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
    public class EmployeeRepo : IEntityRepo<Employee>
    {
        private readonly CoffeeShopContext _context;
        public EmployeeRepo(CoffeeShopContext context)
        {
            _context = context;
        }
        public async Task Create(Employee entity)
        { 
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var foundEmployee = await _context.Employees.SingleOrDefaultAsync(employee => employee.Id == id);
            if (foundEmployee == null)
                return;
            _context.Employees.Remove(foundEmployee);
            await _context.SaveChangesAsync();
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public Employee? GetById(int id)
        {
            
            return _context.Employees.Where(employee => employee.Id == id).SingleOrDefault();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.Where(employee => employee.Id == id).SingleOrDefaultAsync();
        }

        public async Task Update(int id, Employee entity)
        {
            var foundEmployee = await _context.Employees.SingleOrDefaultAsync(employee => employee.Id == id);
            if (foundEmployee is null)
                return;
            foundEmployee.Name = entity.Name;
            foundEmployee.Surname = entity.Surname;
            foundEmployee.EmployeeType = entity.EmployeeType;
            foundEmployee.SalaryPerMonth = entity.SalaryPerMonth;
            await _context.SaveChangesAsync();
        }
    }
}