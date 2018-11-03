namespace Domain
{
    public class ExtraCost
    {
        private ExtraCost()
        {
        }

        public ExtraCost(int costId, decimal value)
        {
            CostId = costId;
            Value = value;
        }

        public int Id { get; private set; }
        public decimal Value { get; private set; }
        public int CostId { get; private set; }
        public Cost Cost { get; private set; }
    }
}
