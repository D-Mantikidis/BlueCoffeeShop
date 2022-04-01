using CoffeeShop.Model;

namespace CoffeeShop.Web.Models
{
    public class ProductCategoryListViewModel
    {
       public ProductTypeEnum ProductType { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }

    
}
