using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class dummydata
    {
        public Customer x=new Customer();
        public Customer y=new Customer();
        public Employee z=new Employee();
        public Employee w=new Employee();
        public TransactionLine l1=new TransactionLine();
        public TransactionLine l2 = new TransactionLine();
        public Product p1 =new Product();
        public Product p2 =new Product();
        public Transaction tr1=new Transaction();
        public Transaction tr2 = new Transaction();
        public ProductCategory c1=new ProductCategory();
        public ProductCategory c2=new ProductCategory();    



        public dummydata()
        {
            //product category
            c1.ProductType = ProductTypeEnum.Beverages;
            c2.ProductType = ProductTypeEnum.Coffee;
           
            //product
            p1.Code = "kafes";
            p2.Code = "frapes";
            p1.Price = 234234;
            p2.Price = 50;
            p2.ProducyCategoryID = 99;
            p1.ProducyCategoryID = 99;

            /*var x = new ProductCategory();

            x.ProductType = ProductTypeEnum.Beverages;

            p1.ProductCategory = x;
            p2.ProductCategory = x;

            p1.*/

            //transactionline
            l1.ProductID = 12;
            l2.ProductID = 13;
            l1.Price = 124;
            l2.Price = 432;
            l1.Discount = 23;
            l2.Discount = 24;
            l1.TotalPrice = 13423;
            l2.TotalPrice = 324234;
            l2.Qty = 2;
            l1.Qty = 3;//transactionLine;

            //transaction
            tr1.TransactionLines.Add(l1);
            tr1.CustomerID = 1232;
            tr1.EmployeeID = 124421;
            tr1.TotalPrice = 3244235;
            tr1.Date = DateTime.Now;
            tr1.PaymentMethod = PaymentMethodEnum.Credit_Card;
            tr2.TransactionLines.Add(l1);
            tr2.CustomerID = 1232;
            tr2.EmployeeID = 124421;
            tr2.TotalPrice = 3244235;
            tr2.Date = DateTime.Now;
            tr2.PaymentMethod = PaymentMethodEnum.Credit_Card;//transaction


            //Employee
            z.Surname = "papadopoulos";
            w.Surname = "faros";
            z.SalaryPerMonth = 234325;
            w.SalaryPerMonth = 1111;
            z.EmployeeType = EmployeeType.Manager;
            w.EmployeeType = EmployeeType.Waiter;//Employee
            


            //customers
            x.Code = "efta";
            x.Description = "kalos";
            x.Id = 13;
            y.Code = "oxto";
            y.Description = "psilos";
            y.Id = 10;//customers
        }
    }
}
