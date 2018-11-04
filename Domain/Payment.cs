using System;

namespace Domain
{
    public class Payment
    {
        private Payment()
        {
        }

        public Payment(int methodId, decimal value)
        {
            MethodId = methodId;
            Value = Math.Abs(value);
        }

        public int Id { get; private set; }
        public decimal Value { get; private set; }
        public int MethodId { get; private set; }
        public PaymentMethod Method { get; private set; }
    }
}
