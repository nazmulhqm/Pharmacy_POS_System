namespace Pharmacy_POS_System.DAL.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IReadOnlyList<TEntity>> Get();
        Task<TEntity> Get(int id);
        Task<object> Post(TEntity entity);
        Task<object> Put(int id, TEntity entity);
        Task<object> Delete(int id);
    }
}
