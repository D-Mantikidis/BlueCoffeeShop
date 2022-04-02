using CoffeeShop.Model;

namespace CoffeeShop.Web.Models
{
    public class TransactionListViewModel
    {
        public TransactionListViewModel()
        {

        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public List<TransactionLine> TransactionLines { get; set; }

    }
    public class TransactionCreateViewModel//
    {
        public TransactionCreateViewModel()
        {

        }
        
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }


        public List<TransactionLine> TransactionLines { get; set; }


    }


    /*public class TransactionDeleteViewModel
    {
        public TransactionDeleteViewModel()
        {

        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public List<TransactionLine> TransactionLines { get; set; }

    }*/




}

