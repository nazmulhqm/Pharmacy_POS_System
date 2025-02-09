using Microsoft.EntityFrameworkCore;
using Pharmacy_POS_System.DAL.Interface;
using Pharmacy_POS_System.Data;
using Pharmacy_POS_System.Entities;

namespace Pharmacy_POS_System.DAL.Repository
{
    public class SaleRepository : ISaleRepository
    {
        readonly PharmacyDbContext _context;
        public SaleRepository(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Sale>> Get()
        {
            return await _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.SaleItems)
                .ThenInclude(si => si.Product)
                .Include(s => s.Payment)
                .ToListAsync();
        }

        public async Task<Sale> Get(int id)
        {
            var sale = await _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.SaleItems)
                .ThenInclude(si => si.Product)
                .Include(s => s.Payment)
                .FirstOrDefaultAsync(s => s.Id == id);
            return sale;
        }

        public async Task<Sale> Post(Sale sale)
        {
            foreach (var saleItem in sale.SaleItems)
            {
                _context.Entry(saleItem).State = EntityState.Added;
                var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == saleItem.ProductId);

                if (product != null)
                {
                    if (product.Stock >= saleItem.Quantity)
                    {
                        product.Stock -= saleItem.Quantity;

                        _context.Entry(product).State = EntityState.Modified;
                    }
                    else
                    {
                        throw new InvalidOperationException("Sock Less: " + product.Name);
                    }
                }
            }
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return sale;
        }

        public async Task<Sale> Put(int id, Sale entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Sale> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
