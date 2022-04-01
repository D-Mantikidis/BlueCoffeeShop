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
        public IEnumerable GetPaymentEnumList()
        {
            var PaymentEnumData = from PaymentMethodEnum e in Enum.GetValues(typeof(PaymentMethodEnum))
                                   select new
                                   {
                                       ID = (int)e,
                                       Name = e.ToString()
                                   };

            return PaymentEnumData;
        }
        public IEnumerable GetProductTypeEnumList()
        {
            var ProductTypeEnumData = from ProductTypeEnum e in Enum.GetValues(typeof(ProductTypeEnum))
                                   select new
                                   {
                                       ID = (int)e,
                                       Name = e.ToString()
                                   };

            return ProductTypeEnumData;
        }
    }

}
