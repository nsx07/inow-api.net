using INOW.API.Entities;
using INOW.API.Models;
using INOW.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace INOW.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class UserController : BaseController<User, long, UserService>
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
                    return this.StatusCode(StatusCodes.Status200OK, delete);
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
                long id = await base.service.Add(entity);
                if (id % 2 == 0)
                {
                    return this.StatusCode(StatusCodes.Status200OK, id);
                }
                return this.StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
