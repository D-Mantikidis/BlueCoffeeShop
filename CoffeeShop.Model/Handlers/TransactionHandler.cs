using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoffeeShop.Model.Handlers
{

    public class TransactionHandler
    {
        private decimal discountPerCent = 0.15m;
        private decimal discountThreshold = 10m;

        public TransactionHandler()
        {

        }

        public void AddTransaction(Transaction trans,TransactionLine transline)
        {
            trans.TransactionLines.Add(transline);
        }

        public void CalcPriceWithDisc(Transaction transaction)
        {
            if (transaction.TotalPrice > 10m)
            {
                transaction.TotalPrice *= (1.0m - discountPerCent);
            }
        }


        public void CalcPrice(Transaction transaction)
        {
            transaction.TotalPrice = transaction.TransactionLines.Sum(x => x.TotalPrice);

            if (transaction.TotalPrice > 10m)
            {
                transaction.TotalPrice *= (1.0m - discountPerCent);
            }
        }
        public decimal CalcCost(Transaction transaction, List<Product> listofproduct)
        {
            //listofproduct is the matrix from database
            var cost = transaction.TransactionLines.Sum(x => x.Qty * listofproduct.FirstOrDefault(y => y.Id==x.ProductID).Cost);
            return cost;
        }
        public decimal CalcTotalProfit(List<Transaction> transactions, List<Product> listofproduct)
        {
           //Loaded from database
            decimal totalCost = 0;
            decimal totalPrice = 0;
            decimal totalProfit = 0;
            foreach (Transaction tran in transactions)
            {
                totalCost += CalcCost(tran,listofproduct);
                totalPrice += tran.TotalPrice;

            }
            totalProfit = totalPrice - totalCost;
            return totalProfit;
        }

        public bool ValidTransaction(Transaction transaction)
        {
            if(transaction.TotalPrice>50 && transaction.PaymentMethod==PaymentMethodEnum.Credit_Card){
                
                return false;
            }

            return true;
        }

    }
}
