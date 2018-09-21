using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface IRepositoryAccount<T> where T : class
    {
        Account FindAccountById(int id);
    }

    public class RepositoryAccount : IRepositoryAccount<Account>
    {

        private readonly string ConnectionString;
        protected IConfiguration _config;

        public RepositoryAccount(IConfiguration config)
        {
            _config = config;
            ConnectionString = _config.GetConnectionString("DefaultConnection");
        }

        public Account FindAccountById(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (var t = conn.BeginTransaction())
                {
                    Account results = conn.Query<Account>(@"SELECT * FROM [dbo].[account] WHERE [id] = @id", new { id }, transaction: t).SingleOrDefault();
                    return results;
                }
            }
        }
    }
}
