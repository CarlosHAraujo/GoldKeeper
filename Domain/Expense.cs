using System;
using System.Collections.Generic;
using System.Linq;

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
        public decimal GrandTotal { get { return Products.Sum(x => x.Price) + ExtraCosts.Sum(x => x.Value) - Discount; } }
        public IEnumerable<Payment> PaymentMethod { get; private set; }
    }
}
