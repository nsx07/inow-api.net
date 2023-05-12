using INOW.API._Entities_;
using INOW.API._Models_;

namespace INOW.API._Services_
{
    public partial class UserService : ServiceBase<User, long>
    {
        public override async Task<long> Add(User entity)
        {
            return await Task.Run(() => { return DateTime.Now.Millisecond; });
        }

        public override async Task<bool> Delete(long id)
        {
            return await Task.Run(() => { return true; });
        }

        public override async Task<long> Edit(User entity)
        {
            return await Task.Run(() => { return DateTime.Now.Millisecond; });
        }

        public override async Task<User> Get(long key)
        {
            return await Task.Run(() => { return new User(); });
        }

        public override async Task<ICollection<User>> GetAll()
        {
            return await Task.Run(() => {
                List<User> users = new List<User>();
                return users;
            });
        }
    }
}
