using System;

namespace Domain
{
    public class Item
    {
        private Item()
        {
        }

        public Item(int productId, decimal value, int quantity)
        {
            ProductId = productId;
            Value = Math.Abs(value);
            Quantity = quantity;
        }

        public int Id { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public decimal Total { get { return Quantity * Value; } }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
    }
}
