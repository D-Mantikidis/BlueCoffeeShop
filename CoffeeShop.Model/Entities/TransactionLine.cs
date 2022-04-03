using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class TransactionLine : BaseEntity
    {
        public TransactionLine()
        {
        }

        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }

        // Entity Framework
        public int TransactionID { get; set; }
        public Transaction Transaction { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
