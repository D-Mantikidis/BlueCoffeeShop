namespace CoffeeShop.Web.Models
{
    public class CustomerListViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

    }

    public class CustomerCreateViewModel
    {
        public string Code { get; set; }
        public string Description { get; set; }

    }

    public class CustomerUpdateViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

    }

    public class CustomerDeleteViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

    }


}
