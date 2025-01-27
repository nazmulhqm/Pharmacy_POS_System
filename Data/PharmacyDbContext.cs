
using Microsoft.EntityFrameworkCore;
using Pharmacy_POS_System.Entities;

namespace Pharmacy_POS_System.Data
{
    public class PharmacyDbContext :DbContext
    {
        public PharmacyDbContext()
        {
        }

        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SaleItem>()
                .HasOne(s => s.Sale)
                .WithMany(si => si.SaleItems)
                .HasForeignKey(s => s.SaleId);

            modelBuilder.Entity<SaleItem>()
                .HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Sale>()
                .HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Payment>()
               .HasOne(p => p.Sale)
               .WithOne(s => s.Payment)
               .HasForeignKey<Payment>(p => p.SaleId);
        }
    }
}

