
namespace INOW.API._Models_
{
    public abstract class ServiceBase<TEntity, TKey> where TEntity : EntityBase
    {

        public abstract Task<ICollection<TEntity>> GetAll();

        public abstract Task<TEntity> Get(TKey key);

        public abstract Task<long> Add(TEntity entity);

        public abstract Task<long> Edit(TEntity entity);

        public abstract Task<Boolean> Delete(TKey id);
    }
}
