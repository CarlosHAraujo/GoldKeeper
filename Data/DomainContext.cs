using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            modelBuilder.Entity<Company>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Company>().HasSoftDelete();

            modelBuilder.Entity<Expense>().Property(x => x.Date).IsRequired();
            modelBuilder.Entity<Expense>().Property(x => x.Discount);
            modelBuilder.Entity<Expense>().HasOne(x => x.Company);
            modelBuilder.Entity<Expense>().HasSoftDelete();

            modelBuilder.Entity<ExtraCost>().Property(x => x.Cost).IsRequired();
            modelBuilder.Entity<ExtraCost>().Property(x => x.Value).IsRequired();
            modelBuilder.Entity<ExtraCost>().HasSoftDelete();

            modelBuilder.Entity<Item>().HasOne(x => x.Product);
            modelBuilder.Entity<Item>().Property(x => x.Quantity).IsRequired();
            modelBuilder.Entity<Item>().Property(x => x.Value).IsRequired();
            modelBuilder.Entity<Item>().HasSoftDelete();

            modelBuilder.Entity<Payment>().HasOne(x => x.Method);
            modelBuilder.Entity<Payment>().Property(x => x.Value).IsRequired();
            modelBuilder.Entity<Payment>().HasSoftDelete();

            modelBuilder.Entity<PaymentMethod>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<PaymentMethod>().HasSoftDelete();

            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Product>().HasSoftDelete();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void HasSoftDelete<TEntity>(this EntityTypeBuilder<TEntity> entity) where TEntity : class
        {
            entity.Property<bool>("IsDeleted");
            entity.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));
        }
    }
}
