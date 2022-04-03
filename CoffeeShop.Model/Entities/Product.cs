using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class Product : ProductEntity
    {
        public int ProductCategoryID { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }

        // Entity Framework
        public ProductCategory ProductCategory { get; set; }
        public List<TransactionLine> TransactionLines { get; set; }

        public Product()
        {

        }
    }
}
