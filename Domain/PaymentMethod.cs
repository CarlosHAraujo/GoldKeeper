using Shared.Extensions;

namespace Domain
{
    public class PaymentMethod
    {
        private PaymentMethod()
        {
        }

        public PaymentMethod(string name)
        {
            Name = name.CheckNullOrWhiteSpace();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
