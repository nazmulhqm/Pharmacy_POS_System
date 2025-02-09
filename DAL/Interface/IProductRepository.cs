using Pharmacy_POS_System.Entities;

namespace Pharmacy_POS_System.DAL.Interface
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsAsync(int? categoryId, int? brandId, string? searchTerm);
    }
}
