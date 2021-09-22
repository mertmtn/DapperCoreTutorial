using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DbConnect
    {
        private static SqlConnection _connection;

        public static SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    var connectionString = ConnectionString;
                    _connection = new SqlConnection(connectionString);
                }

                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }
 
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
