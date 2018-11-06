using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Expense
    {
        private readonly List<ExtraCost> _extraCosts = new List<ExtraCost>();
        private readonly List<Payment> _payments = new List<Payment>();
        private readonly List<Item> _items = new List<Item>();

        private Expense()
        {
        }

        public Expense(int companyId, DateTime date, decimal discount = 0)
        {
            CompanyId = companyId;
            Date = date;
            Discount = Math.Abs(discount);
        }

        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Discount { get; private set; }
        public decimal GrandTotal { get { return _items.Sum(x => x.Total) + _extraCosts.Sum(x => x.Value) - Discount; } }
        public int? CompanyId { get; private set; }
        public Company Company { get; private set; }
        public IReadOnlyList<Payment> Payments { get { return _payments.AsReadOnly(); } }
        public IReadOnlyList<ExtraCost> ExtraCosts { get { return _extraCosts.AsReadOnly(); } }
        public IReadOnlyList<Item> Items { get { return _items.AsReadOnly(); } }

        public Item AddItem(int productId, decimal value, int quantity)
        {
            var item = new Item(productId, value, quantity);
            _items.Add(item);
            return item;
        }

        public Payment AddPayment(int methodId, decimal value)
        {
            var payment = new Payment(methodId, value);
            _payments.Add(payment);
            return payment;
        }

        public ExtraCost AddExtraCost(string cost, decimal value)
        {
            var extraCost = new ExtraCost(cost, value);
            _extraCosts.Add(extraCost);
            return extraCost;
        }
    }
}
