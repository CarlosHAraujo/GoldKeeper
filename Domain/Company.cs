using Shared.Extensions;

namespace Domain
{
    public class Company
    {
        private Company()
        {
        }

        public Company(string name)
        {
            this.Name = name.CheckEmptyOrWhiteSpace();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
