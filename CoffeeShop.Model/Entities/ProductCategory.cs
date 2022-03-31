using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class ProductCategory : ProductEntity
    {
        public ProductTypeEnum ProductType { get; set; }

        // Entity Framework
        public List<Product> Products { get; set; }

        public ProductCategory()
        {
            Products = new List<Product>();
        }
    }
}
