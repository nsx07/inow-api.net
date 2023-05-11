namespace INOW.API._Entities_
{
    public partial class User : Base<int>
    {
        public string Name { get; set; }

        public string FamilyName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }
    }

}