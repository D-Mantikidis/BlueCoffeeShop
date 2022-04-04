using CoffeeShop.Model;

namespace CoffeeShop.Web.Models
{
    public class TransactionListViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public List<TransactionLineViewModel> TransactionLines { get; set; } = new List<TransactionLineViewModel>();
    }

    public class TransactionCreateViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public List<TransactionLine>? TransactionLines { get; set; }
    }

    public class TransactionDetailViewModel
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime? Date { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public string Customer { get; set; }
        public string Employee { get; set; }
        public int Id { get; set; }

        public List<TransactionLineDetailViewModel>? TransactionLines { get; set; } = new List<TransactionLineDetailViewModel>();  
    }

}

