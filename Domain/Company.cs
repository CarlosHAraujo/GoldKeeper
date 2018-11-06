using System.Collections.Generic;
using Shared.Extensions;

namespace Domain
{
    public class Company
    {
        private readonly List<Expense> _expenses = new List<Expense>();
        private Company()
        {
        }

        public Company(string name)
        {
            this.Name = name.CheckNullOrWhiteSpace();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyList<Expense> Expenses { get { return _expenses.AsReadOnly(); } }
    }
}
