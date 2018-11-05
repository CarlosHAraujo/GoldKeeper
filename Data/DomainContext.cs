using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DomainContext : DbContext
    {
        public DomainContext(DbContextOptions<DomainContext> options) : base(options)
        {
        }

        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
