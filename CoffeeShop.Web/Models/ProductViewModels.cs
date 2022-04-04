using CoffeeShop.Model;

namespace CoffeeShop.Web.Models
{
    public class ProductListViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ProductCategory { get; set; }
        
    }

    public class ProductCreateViewModel
    {
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ProductCategoryID { get; set; }
    }

    public class ProductDeleteViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ProductCategory { get; set; }
    }

    public class ProductUpdateViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int ProductCategoryID { get; set; }
    }
}
