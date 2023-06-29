using INOW.API.Entities;
using INOW.API.Models;
using INOW.API.Persistence;
using INOW.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace INOW.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public partial class UserController : BaseController<User, long, UserService, UserRepository>
    {
        public UserController(UserService service) : base(service)
        {
        }

        [HttpDelete("{id}")]
        public async Task<dynamic> Delete(long id)
        {
            try
            {
                var delete = await service.Delete(id);
                if (delete != null) {
                    
                    return this.StatusCode(StatusCodes.Status200OK, delete);
                }
                return this.StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<dynamic> Get(long id)
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

        [HttpGet]
        public async Task<dynamic> GetAll()
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

        [HttpPost]
        public async Task<dynamic> Post([FromBody] User entity)
        {
            try
            {

                if (entity.Id != null && entity.Id >= 1)
                {
                    User? user = await base.service.Edit(entity);
                    return this.StatusCode(StatusCodes.Status200OK, user);

                } else
                {
                    long id = await base.service.Add(entity);
                    if (id > 0)
                    {
                        return this.StatusCode(StatusCodes.Status200OK, id);
                    }

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
