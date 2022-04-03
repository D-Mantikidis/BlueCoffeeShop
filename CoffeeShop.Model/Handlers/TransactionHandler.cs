using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.Handlers
{
    public class TransactionHandler
    {
        public TransactionHandler()
        {

        }

        public decimal GetTotalPrice(Transaction transaction)
        {
            return transaction.TransactionLines.Sum(x => x.TotalPrice);
        }

        public void ApplyDiscount(Transaction transaction, float discount, decimal limit)
        {
            if (transaction.TotalPrice > limit)
            {
                transaction.TotalPrice -= transaction.TotalPrice * (decimal)discount;
            }
        }

        public List<PaymentMethodEnum> CheckPaymentMethod(Transaction transaction, decimal limit)
        {
            var paymentMethods = new List<PaymentMethodEnum>();

            if (transaction.TotalPrice > limit)
            {
                paymentMethods.Add(PaymentMethodEnum.Cash);
                return paymentMethods;
            }

            paymentMethods.Add(PaymentMethodEnum.Cash);
            paymentMethods.Add(PaymentMethodEnum.Credit_Card);
            return paymentMethods;

        }
    }
}
