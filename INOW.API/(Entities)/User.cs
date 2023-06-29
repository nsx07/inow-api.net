using INOW.API.Models;

namespace INOW.API.Entities
{
    public partial class User : EntityBase, IIdentifiable<long>
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }

        public virtual string FamilyName { get; set; }

        public virtual string Email { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Password { get; set; }
    }

}