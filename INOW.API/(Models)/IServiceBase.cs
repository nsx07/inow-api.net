namespace INOW.API.Models
{
    public interface IServiceBase<TEntity, TKey, TRepository>
    {
        IQueryable<TEntity> GetQueryAble();
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(TKey key);
        Task<TKey?> Add(TEntity entity);
        Task<TEntity?> Edit(TEntity entity);
        Task<TKey?> Delete(TKey id);
    }
}
