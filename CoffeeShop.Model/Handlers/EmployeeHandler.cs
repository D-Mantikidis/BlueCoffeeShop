using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.Handlers
{
    public class EmployeeHandler
    {
        public EmployeeHandler()
        {

        }

        public bool CheckStaffAvail(EmployeeType employeeType, List<Employee> employees, int limit)
        {
            if (employees.Where(employee => employee.EmployeeType == employeeType).Count() == limit)
                return false;
            
            return true;
        }
    }
}
