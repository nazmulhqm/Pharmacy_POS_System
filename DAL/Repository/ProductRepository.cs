using Microsoft.EntityFrameworkCore;
using Pharmacy_POS_System.DAL.Interface;
using Pharmacy_POS_System.Data;
using Pharmacy_POS_System.Entities;

namespace Pharmacy_POS_System.DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly PharmacyDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public ProductRepository(PharmacyDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<object> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return product;
        }

        public async Task<IReadOnlyList<Product>> Get()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Set<Product>()
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

        }

        public async Task<object> Post(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.Image != null)
            {
                entity.ProductImage = await UploadImageAsync(entity.Image);
            }

            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, Product entity)
        {
            var existingEntity = await _context.Products.FindAsync(id);


            if (entity.Image != null)
            {
                existingEntity.ProductImage = await UploadImageAsync(entity.Image);
            }

            existingEntity.Name = entity.Name;
            existingEntity.Description = entity.Description;
            existingEntity.Price = entity.Price;
            existingEntity.CategoryId = entity.CategoryId;
            existingEntity.Stock = entity.Stock;

            _context.Entry(existingEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingEntity;
        }

        private async Task<string> UploadImageAsync(IFormFile imageFile)
        {
            string uploadsFolder = Path.Combine(_environment.WebRootPath, "ProductImage");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            var imgUrl = "http://localhost:5297/" + "ProductImage/" + uniqueFileName;

            return imgUrl;
        }
    }
}
