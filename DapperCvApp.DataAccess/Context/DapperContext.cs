using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DapperCvApp.DataAccess.Context
{
    public class DapperContext
    {

        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = this.configuration.GetConnectionString("MsSql");
        }

        public IDbConnection CreateConnection()
        {
             return  new SqlConnection(connectionString);
        }

    }
}
