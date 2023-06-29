using INOW.API.Core;
using MongoDB.Driver;
using NHibernate.SqlCommand;

namespace INOW.API.Models
{
    public abstract class ServiceBase<TEntity, TKey, TRepository> : IServiceBase<TEntity, TKey, TRepository>
        where TEntity : EntityBase, IIdentifiable<TKey>
        where TRepository : IRepository<TEntity, TKey>
    {
        public TRepository Repository { get; set; }

        public ServiceBase(TRepository repository) {
            this.Repository = repository;
        }

        public virtual IQueryable<TEntity> GetQueryAble()
        {
            return this.Repository.GetQueryable();
        }

        public Task<List<TEntity>> GetAll() {
            return this.Repository.FindAll();
        }

        public Task<TEntity> Get(TKey key)
        {
            return this.Repository.FindById(key);
        }

        public async Task<TKey?> Add(TEntity entity)
        {
            var entityToInsert = await this.Repository.Add(entity);

            if (entityToInsert != null)
            {
                return entityToInsert;
            }
            return default;
        }

        public async Task<TEntity?> Edit(TEntity entity)
        {
            var entityToUpdate = await this.Repository.Update(entity);

            if (entityToUpdate != null)
            {
                return entityToUpdate;
            }
            return default;
        }

        public async Task<TKey?> Delete(TKey id)
        {
            var deleted = await this.Repository.Remove(id);

            if (deleted != null)
            {
                return deleted;
            }
            return default;
        }
    }
}
