using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class Transaction : BaseEntity
    {
        public Transaction()
        {
            Date = DateTime.Now;
            TransactionLines = new List<TransactionLine>();
           /* Customer = new Customer();
            Employee = new Employee();*/
        }

        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }

        // Entity Framework
        public List<TransactionLine> TransactionLines { get; set; }//xreiazete
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }

    }
}
