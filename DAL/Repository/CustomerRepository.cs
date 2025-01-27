using Pharmacy_POS_System.DAL.Interface;
using Pharmacy_POS_System.Data;
using Pharmacy_POS_System.Entities;
using Microsoft.EntityFrameworkCore;

namespace Pharmacy_POS_System.DAL.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        readonly PharmacyDbContext _context;
        public CustomerRepository(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Customer>> Get()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> Get(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return customer;
        }

        public async Task<object> Post(Customer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, Customer entity)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (_context.Customers.Any(c => c.Id != id))
            {
                return null;
            }
            customer.Name = entity.Name;
            customer.PhoneNumber = entity.PhoneNumber;
            customer.Address = entity.Address;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            return null;
        }

    }
}
