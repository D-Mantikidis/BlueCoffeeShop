using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.Handlers
{
    public class EnumsHandler
    {
        public EnumsHandler()
        {

        }

        public IEnumerable GetEmployeeEnumList()
        {
            var employeeEnumData = from EmployeeType e in Enum.GetValues(typeof(EmployeeType))
                                   select new
                                   {
                                       ID = (int)e,
                                       Name = e.ToString()
                                   };

            return employeeEnumData;
        }
    }

}
