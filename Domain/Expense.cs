using System;
using System.Collections.Generic;

namespace Domain
{
    public class Expense
    {
        public Company Company { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Cost> ExtraCosts { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public IEnumerable<Payment> PaymentMethod { get; set; }
    }
}
