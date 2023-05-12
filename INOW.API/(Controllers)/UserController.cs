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

        public override async Task<dynamic> Delete(long id)
        {
            try
            {
                bool delete = await base.service.Delete(id);
                if (delete) {
                    return this.StatusCode(StatusCodes.Status200OK);
                }
                return this.StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        public override async Task<dynamic> Get(long id)
        {
            try
            {
                return await base.service.Get(id);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        public override async Task<dynamic> GetAll()
        {
            try
            {
                return await base.service.GetAll(); 
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        public override async Task<dynamic> Post([FromBody] User entity)
        {
            try
            {
                return await base.service.Add(entity);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
