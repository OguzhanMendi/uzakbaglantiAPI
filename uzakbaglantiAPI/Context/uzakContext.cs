using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using uzakbaglantiAPI.Entities;

namespace uzakbaglantiAPI.Context
{
    public class uzakContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;


        public uzakContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlCon");
        }

        public IDbConnection CreateSqlConnection() => new SqlConnection( _connectionString );

        public DbSet<Kullanici> kullanici { get; set; }

        public DbSet<Baglanti> Baglanti { get; set; }
    }
}
