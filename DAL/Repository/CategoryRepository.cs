using Microsoft.EntityFrameworkCore;
using Pharmacy_POS_System.DAL.Interface;
using Pharmacy_POS_System.Data;
using Pharmacy_POS_System.Entities;

namespace Pharmacy_POS_System.DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly PharmacyDbContext _context;
        public CategoryRepository(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Category>> Get()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> Get(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category;
        }

        public async Task<object> Post(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (_context.Categories.Any(c => c.Name == entity.Name))
            {
                return null;
            }

            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, Category entity)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (_context.Categories.Any(c => c.CategoryId != id && c.Name == entity.Name))
            {
                return null;
            }
            category.Name = entity.Name;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return category;
            }
            return null;
        }
    }
}
