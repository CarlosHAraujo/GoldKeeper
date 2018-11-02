using System;
using System.Collections.Generic;

namespace Domain
{
    public class Expense
    {
        public int Id { get; private set; }
        public Company Company { get; private set; }
        public DateTime Date { get; private set; }
        public IEnumerable<Product> Products { get; private set; }
        public IEnumerable<ExtraCost> ExtraCosts { get; private set; }
        public decimal Discount { get; private set; }
        public decimal GrandTotal { get; private set; }
        public IEnumerable<Payment> PaymentMethod { get; private set; }
    }
}
