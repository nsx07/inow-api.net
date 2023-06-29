using NHibernate;
using NHibernate.Linq;
using ISession = NHibernate.ISession;

namespace INOW.API.Models
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : EntityBase, IIdentifiable<TKey>
    {
        private ISession _session;
        public Repository(ISession session) => _session = session;

        public IQueryable<TEntity> GetQueryable()
        {
            return this._session.Query<TEntity>();
        }

        public async Task<TKey?> Add(TEntity item)
        {
            ITransaction transaction = null;
            TKey id;
            try
            {
                transaction = _session.BeginTransaction();
                id = (TKey) await _session.SaveAsync(item);
                await transaction.CommitAsync();
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await transaction?.RollbackAsync();
                return default;
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public Task<List<TEntity>> FindAll()
        {
            return _session.Query<TEntity>().ToListAsync();
        }
                        
        public async Task<TEntity?> FindById(TKey id)
        {
            return await _session.GetAsync<TEntity>(id);
        }
                        
        public async Task<TKey?> Remove(TKey id)
        {
            ITransaction transaction = null;

            try
            {
                transaction = _session.BeginTransaction();
                var item = await _session.GetAsync<TEntity>(id);
                await _session.DeleteAsync(item);
                await transaction.CommitAsync();

                return id;
            }
            catch (Exception ex)
            {
                await transaction?.RollbackAsync();
                return default;
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public async Task<TEntity?> Update(TEntity entity)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.UpdateAsync(entity);
                await transaction.CommitAsync();

                return entity;
            }
            catch (Exception ex)
            {
                await transaction?.RollbackAsync();
                return default;
            }
            finally
            {
                transaction?.Dispose();
            }
        }
    }
}
