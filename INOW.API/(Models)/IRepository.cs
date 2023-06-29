namespace INOW.API.Models
{
    public interface IRepository<TEntity, TKey>
    {
        IQueryable<TEntity> GetQueryable();
        Task<TKey?> Add(TEntity item);
        Task<TKey?> Remove(TKey id);
        Task<TEntity?> Update(TEntity item);
        Task<TEntity?> FindById(TKey id);
        Task<List<TEntity>> FindAll();
    }
}
