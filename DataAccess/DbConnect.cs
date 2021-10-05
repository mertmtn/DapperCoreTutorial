using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DbConnect
    {
        public static SqlConnection Connection => new SqlConnection(ConnectionString);

        public static string ConnectionString
        {
            get
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                return config.GetConnectionString("DefaultConnection");
            }
        }
    }
}
