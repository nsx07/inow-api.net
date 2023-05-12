using Microsoft.AspNetCore.Mvc;

namespace INOW.API._Models_
{
    public abstract class BaseController<TEntity, TKey, TService> : ControllerBase 
        where TEntity : EntityBase, IIdentifiable<TKey>, 
        new() where TService : ServiceBase<TEntity, TKey>
    {
        protected ServiceBase<TEntity, TKey> service;

        public BaseController(ServiceBase<TEntity, TKey> service)
        {
            this.service = service;
        }

        [HttpGet]
        public abstract Task<ICollection<TEntity>> GetAll();


        [HttpGet("{id}")]
        public abstract Task<TEntity> Get(TKey id);

        [HttpPost]
        public abstract Task<TKey> Post([FromBody] TEntity entity);


        [HttpDelete("{id}")]
        public abstract Task<Boolean> Delete(TKey id);
    }
}
