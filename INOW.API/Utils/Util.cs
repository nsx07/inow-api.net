namespace INOW.API.Utils
{
    public class Util
    {
        public static string getConnectionStringFromEnvironment() {
            string PGDATABASE = Environment.GetEnvironmentVariable("PGDATABASE") ?? "";
            string PGPASSWORD = Environment.GetEnvironmentVariable("PGPASSWORD") ?? "";
            string PGHOST = Environment.GetEnvironmentVariable("PGHOST") ?? "";
            string PGPORT = Environment.GetEnvironmentVariable("PGPORT") ?? "";
            string PGUSER = Environment.GetEnvironmentVariable("PGUSER") ?? "";

            string url = $"Server={PGHOST};Port={PGPORT};Database={PGDATABASE}; User Id={PGUSER}; Password={PGPASSWORD}";

            return url;
        }
    }
}
