
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
        public DbSet<Brand> Brands { get; set; }

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

            modelBuilder.Entity<Product>()
                .HasOne(c => c.Brand)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.BrandId);

            modelBuilder.Entity<Payment>()
               .HasOne(p => p.Sale)
               .WithOne(s => s.Payment)
               .HasForeignKey<Payment>(p => p.SaleId);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Pain Relief" },
                new Category { CategoryId = 2, Name = "Allergy & Sinus" },
                new Category { CategoryId = 3, Name = "Cold & Flu" },
                new Category { CategoryId = 4, Name = "Vitamins & Supplements" },
                new Category { CategoryId = 5, Name = "Skin Care" },
                new Category { CategoryId = 6, Name = "Digestive Health" },
                new Category { CategoryId = 7, Name = "First Aid" },
                new Category { CategoryId = 8, Name = "Diabetes Care" }
            );

            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandId = 1, Name = "Tylenol" },
                new Brand { BrandId = 2, Name = "Advil" },
                new Brand { BrandId = 3, Name = "Zyrtec" },
                new Brand { BrandId = 4, Name = "Nature Made" },
                new Brand { BrandId = 5, Name = "Neutrogena" },
                new Brand { BrandId = 6, Name = "Vicks" },
                new Brand { BrandId = 7, Name = "Pepto-Bismol" },
                new Brand { BrandId = 8, Name = "Bayer" },
                new Brand { BrandId = 9, Name = "Aquaphor" },
                new Brand { BrandId = 10, Name = "Glucerna" }
            );

            modelBuilder.Entity<Product>().HasData(
                    new Product { Id = 1, Name = "Tylenol Extra Strength", Description = "Pain reliever and fever reducer.", CategoryId = 1, BrandId = 1, ProductImage = "tylenol.jpg", Stock = 100, Price = 5.99, DefaultDiscount = 0 },
                    new Product { Id = 2, Name = "Advil Liqui-Gels", Description = "Fast pain relief for headaches and muscle aches.", CategoryId = 1, BrandId = 2, ProductImage = "advil.jpg", Stock = 120, Price = 6.49, DefaultDiscount = 0 },
                    new Product { Id = 3, Name = "Bayer Aspirin", Description = "Pain relief and heart health support.", CategoryId = 1, BrandId = 8, ProductImage = "bayer.jpg", Stock = 90, Price = 4.99, DefaultDiscount = 8 },

                    new Product { Id = 4, Name = "Zyrtec Allergy Tablets", Description = "24-hour allergy relief.", CategoryId = 2, BrandId = 3, ProductImage = "zyrtec.jpg", Stock = 80, Price = 12.99, DefaultDiscount = 8 },
                    new Product { Id = 5, Name = "Claritin Non-Drowsy", Description = "Fast-acting allergy relief.", CategoryId = 2, BrandId = 3, ProductImage = "claritin.jpg", Stock = 110, Price = 14.99, DefaultDiscount = 7 },
                    new Product { Id = 6, Name = "Flonase Nasal Spray", Description = "Allergy nasal relief spray.", CategoryId = 2, BrandId = 3, ProductImage = "flonase.jpg", Stock = 75, Price = 18.99, DefaultDiscount = 0 },

                    new Product { Id = 7, Name = "Vicks DayQuil", Description = "Cold and flu relief.", CategoryId = 3, BrandId = 6, ProductImage = "dayquil.jpg", Stock = 95, Price = 8.99, DefaultDiscount = 0 },
                    new Product { Id = 8, Name = "Vicks NyQuil", Description = "Nighttime flu relief.", CategoryId = 3, BrandId = 6, ProductImage = "nyquil.jpg", Stock = 90, Price = 9.49, DefaultDiscount = 6 },
                    new Product { Id = 9, Name = "Mucinex DM", Description = "Expectorant and cough suppressant.", CategoryId = 3, BrandId = 6, ProductImage = "mucinex.jpg", Stock = 85, Price = 11.99, DefaultDiscount = 8 },

                    new Product { Id = 10, Name = "Vitamin C Gummies", Description = "Supports immune health.", CategoryId = 4, BrandId = 4, ProductImage = "vitamin_c.jpg", Stock = 150, Price = 9.99, DefaultDiscount = 7 },
                    new Product { Id = 11, Name = "Nature Made Multivitamin", Description = "Daily essential vitamins.", CategoryId = 4, BrandId = 4, ProductImage = "multivitamin.jpg", Stock = 130, Price = 13.99, DefaultDiscount = 0 },
                    new Product { Id = 12, Name = "Fish Oil Omega-3", Description = "Supports heart and brain health.", CategoryId = 4, BrandId = 4, ProductImage = "fish_oil.jpg", Stock = 110, Price = 15.99, DefaultDiscount = 8 }

                );
        }
    }
}

