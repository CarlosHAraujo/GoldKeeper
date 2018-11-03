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

        public Expense(Company company, DateTime date, decimal discount = 0)
        {
            Company = company;
            Date = date;
            Discount = discount;
        }

        public int Id { get; private set; }
        public Company Company { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Discount { get; private set; }
        public decimal GrandTotal { get { return _items.Sum(x => x.Total) + _extraCosts.Sum(x => x.Value) - Discount; } }
        public IReadOnlyList<Payment> Payments { get { return _payments.AsReadOnly(); } }
        public IReadOnlyList<ExtraCost> ExtraCosts { get { return _extraCosts.AsReadOnly(); } }
        public IReadOnlyList<Item> Items { get { return _items.AsReadOnly(); } }

        public void AddItems(IEnumerable<(int productId, decimal value, int quantity)> itens)
        {
            _items.AddRange(itens.Select(i => new Item(i.productId, i.value, i.quantity)));
        }

        public void AddPayments(IEnumerable<(int paymentId, decimal value)> payments)
        {
            _payments.AddRange(payments.Select(p => new Payment(p.paymentId, p.value)));
        }

        public void AddExtraCosts(IEnumerable<(int costId, decimal value)> extraCosts)
        {
            _extraCosts.AddRange(extraCosts.Select(c => new ExtraCost(c.costId, c.value)));
        }
    }
}
