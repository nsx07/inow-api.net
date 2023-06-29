using INOW.API.Entities;
using INOW.API.Models;

namespace INOW.API.Persistence
{
    public class UserRepository : Repository<User, long>
    {
        public UserRepository(NHibernate.ISession session) : base(session)
        {
        }
    }
}
