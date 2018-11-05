using Shared.Extensions;

namespace Domain
{
    public class Product
    {
        private Product()
        {
        }

        public Product(string name)
        {
            Name = name.CheckNullOrWhiteSpace();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
