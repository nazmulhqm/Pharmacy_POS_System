using Microsoft.EntityFrameworkCore;
using Pharmacy_POS_System.DAL.Interface;
using Pharmacy_POS_System.Data;
using Pharmacy_POS_System.Entities;

namespace Pharmacy_POS_System.DAL.Repository
{
    public class BrandRepository : IBrandRepository
    {
        readonly PharmacyDbContext _context;
        public BrandRepository(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Brand>> Get()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> Get(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            return brand;
        }

        public async Task<object> Post(Brand entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (_context.Brands.Any(c => c.Name == entity.Name))
            {
                return null;
            }

            _context.Brands.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, Brand entity)
        {
            var brand = _context.Brands.Find(id);
            if (brand == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (_context.Brands.Any(c => c.BrandId != id && c.Name == entity.Name))
            {
                return null;
            }
            brand.Name = entity.Name;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Delete(int id)
        {
            var brand = _context.Brands.Find(id);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();
                return brand;
            }
            return null;
        }
    }
}
