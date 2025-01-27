using Pharmacy_POS_System.Entities;

namespace Pharmacy_POS_System.DAL.Interface
{
    public interface ISaleRepository
    {
        Task<IReadOnlyList<Sale>> Get();
        Task<Sale> Get(int id);
        Task<Sale> Post(Sale entity);
        Task<Sale> Put(int id, Sale entity);
        Task<Sale> Delete(int id);
    }
}
