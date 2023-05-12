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
        public abstract Task<dynamic> GetAll();


        [HttpGet("{id}")]
        public abstract Task<dynamic> Get(TKey id);

        [HttpPost]
        public abstract Task<dynamic> Post([FromBody] TEntity entity);


        [HttpDelete("{id}")]
        public abstract Task<dynamic> Delete(TKey id);
    }
}
