namespace INOW.API.Security
{
    public class AuthRequest
    {
        public String Identity { get; set; }
        public String Password { get; set; }
    }

    public class AuthRequestResponse
    {
        public Boolean Logged { get; set; }
        public String? Message { get; set; }

    }
}
