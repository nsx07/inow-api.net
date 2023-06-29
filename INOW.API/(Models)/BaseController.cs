using INOW.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace INOW.API.Models
{
    public abstract class BaseController<TEntity, TKey, TService, TRepository> : ControllerBase 
        where TEntity : EntityBase, IIdentifiable<TKey>
        where TRepository: IRepository<TEntity, TKey>
        where TService : IServiceBase<TEntity, TKey, TRepository>
    {
        protected IServiceBase<TEntity, TKey, TRepository> service;

        public BaseController(IServiceBase<TEntity, TKey, TRepository> service)
        {
            this.service = service;
        }

    }
}
