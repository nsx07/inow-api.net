using INOW.API.Entities;
using INOW.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INOW.API.Security
{
    [Route("Security/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public UserService UserService { get; set; }

        public AuthController(UserService userService) {
            this.UserService= userService;
        }

        [HttpPost]
        [Route("Login")]
        public dynamic Login([FromBody] AuthRequest request)
        {
            IQueryable<User> query = this.UserService.GetQueryAble();
            AuthRequestResponse response = new AuthRequestResponse();

            User? user = query.FirstOrDefault(x => x.Email == request.Identity || x.Phone == request.Identity);

            if (user != null) {
                
                if (user.Password == request.Password) {
                    response.Logged = true;
                    response.Message = "Logged successfully";

                    return StatusCode(StatusCodes.Status200OK, response);
                }

            }

            response.Logged = false;
            response.Message = "Identity not found!";

            return StatusCode(StatusCodes.Status400BadRequest, response);
        }

    }
}
