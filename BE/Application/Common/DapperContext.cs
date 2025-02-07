using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CleanArchitecture.ApplicationCore.Common
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
        IDbConnection CreateMainConnection();
    }

    public sealed class DapperContext : IDapperContext
    {
        private readonly string _connectionString;
        private readonly string _mainconnectionString;

        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connect");
            _mainconnectionString = configuration.GetConnectionString("connect");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

        public IDbConnection CreateMainConnection()
           => new SqlConnection(_mainconnectionString);
    }
}
