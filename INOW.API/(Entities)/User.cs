using INOW.API.Models;

namespace INOW.API.Entities
{
    public partial class User : EntityBase, IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string FamilyName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }
    }

}