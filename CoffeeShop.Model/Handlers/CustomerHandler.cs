using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.Handlers
{
    public class CustomerHandler
    {
        public CustomerHandler()
        {

        }

        public bool CheckCustomerAvail(IEnumerable<Customer> customers, int limit)
        {
            if (customers.Count() == limit)
                return false;
            return true;
        }
    }
}
