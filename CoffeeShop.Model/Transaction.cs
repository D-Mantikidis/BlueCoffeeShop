﻿using System;
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

        }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
    }
}
