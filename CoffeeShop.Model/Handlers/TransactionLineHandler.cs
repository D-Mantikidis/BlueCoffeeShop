using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Globalization;

namespace CoffeeShop.Model.Handlers
{
    public class TransactionLineHandler
    {

        public TransactionLineHandler()
        {

        }

        public decimal GetTotalPrice(TransactionLine transactionLine)
        {
            return (transactionLine.Qty * transactionLine.Price) - (transactionLine.Qty * transactionLine.Price) * transactionLine.Discount;
        }

    }
}
