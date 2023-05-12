using INOW.API._Entities_;
using INOW.API._Models_;
using INOW.API._Services_;
using Microsoft.AspNetCore.Mvc;

namespace INOW.API._Controllers_
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, long, UserService>
    {
        public UserController(UserService service) : base(service)
        {
        }

        public override async Task<bool> Delete(long id)
        {
            return await base.service.Delete(id);
        }

        public override async Task<User> Get(long id)
        {
            return await base.service.Get(id);
        }

        public override async Task<ICollection<User>> GetAll()
        {
            return await base.service.GetAll(); 
        }

        public override async Task<long> Post([FromBody] User entity)
        {
            return await base.service.Add(entity);
        }
    }
}
