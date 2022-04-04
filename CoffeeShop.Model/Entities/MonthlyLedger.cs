using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class MonthlyLedger : BaseEntity
    {
        public MonthlyLedger()
        {
            Date = DateTime.Now;
        }

        public DateTime Date { get; set; }
        public int Year { get { return Date.Year; } }
        public int Month { get { return Date.Month; } }
        public decimal Expenses { get; set; }
        public decimal Income { get; set; }
        public decimal Total { get; set; }

    }
}
