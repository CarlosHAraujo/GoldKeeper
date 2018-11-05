using Shared.Extensions;
using System;

namespace Domain
{
    public class ExtraCost
    {
        private ExtraCost()
        {
        }

        public ExtraCost(string cost, decimal value)
        {
            Cost = cost.CheckNullOrWhiteSpace();
            Value = Math.Abs(value);
        }

        public int Id { get; private set; }
        public decimal Value { get; private set; }
        public string Cost { get; private set; }
    }
}
