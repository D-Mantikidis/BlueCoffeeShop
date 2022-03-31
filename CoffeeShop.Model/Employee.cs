using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public enum EmployeeType
    {
        Manager,
        Cashier,
        Barista,
        Waiter
    }
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public decimal SalaryPerMonth { get; set; }
        public EmployeeType EmployeeType { get; set; }

    }
}
