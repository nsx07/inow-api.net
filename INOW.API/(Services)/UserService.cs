using INOW.API.Core;
using INOW.API.Entities;
using INOW.API.Models;
using INOW.API.Persistence;

namespace INOW.API.Services
{
    public partial class UserService : ServiceBase<User, long, UserRepository>
    {
        public UserService(UserRepository repository) : base(repository)
        {
        }
    }
}
