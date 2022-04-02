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
    public class ProductCategoryCreateViewModel
    {
        public int ProductType { get; set; }
       
        public string Code { get; set; }
        public string Description { get; set; }
    }
    public class ProductCategoryUpdateViewModel
    {
        public ProductTypeEnum ProductType { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
    public class ProductCategoryDeleteViewModel
    {
        public ProductTypeEnum ProductType { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }


}
