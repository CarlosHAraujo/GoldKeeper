namespace Domain
{
    public class PaymentMethod
    {
        public int Id { get; private set; }
        public Payment Payment { get; private set; }
        public decimal Value { get; private set; }
    }
}