using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class ProductEntity : BaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public ProductEntity()
        {
            Description = string.Empty;
            Code = string.Empty;
        }
    }
}
