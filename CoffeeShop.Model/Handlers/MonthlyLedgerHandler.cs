using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.Handlers
{
    public class MonthlyLedgerHandler
    {
        public MonthlyLedgerHandler()
        {

        }

        public decimal GetMonthlyIncome(DateTime date, IEnumerable<Transaction> transactions)
        {
            decimal monthlyIncome = 0;

            foreach (var transaction in transactions.Where(transaction => transaction.Date.Year == date.Year &&
                                                           transaction.Date.Month == date.Month))
            {
                monthlyIncome += transaction.TotalPrice;
            }

            return monthlyIncome;
        }

        public decimal GetMonthlyExpenses(DateTime date, IEnumerable<Transaction> transactions)
        {
            decimal monthlyExpenses = 3000;
            var monthlyTransactions = (List<Transaction>)transactions.Where(transaction => transaction.Date.Year == date.Year &&
                                           transaction.Date.Month == date.Month);  
            foreach (var trans in monthlyTransactions)
            {
                monthlyExpenses += trans.TransactionLines.Sum(transactionLine => transactionLine.Product.Cost);
            }

            return monthlyExpenses;
        }
    }
}
