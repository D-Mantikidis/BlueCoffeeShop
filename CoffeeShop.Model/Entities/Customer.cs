using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class Customer : BaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        //entity framework

        public List<Transaction> Transactions { get; set; }
        public Customer()
        {

        }


    }
}
