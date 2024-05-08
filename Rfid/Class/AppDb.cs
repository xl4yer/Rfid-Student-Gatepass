namespace Rfid.Class
{
    public class AppDb
    {
        public IConfiguration Configuration { get; }
        public string GetConnection() => Configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

        public AppDb(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
