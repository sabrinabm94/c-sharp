using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface IRepositoryUser<T> where T : class
    {
        User FindUserById(int id);
    }

    public class RepositoryUser : IRepositoryUser<User>
    {

        private readonly string ConnectionString;
        protected IConfiguration _config;

        public RepositoryUser(IConfiguration config)
        {
            _config = config;
            ConnectionString = _config.GetConnectionString("DefaultConnection");
        }

        public User FindUserById(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (var t = conn.BeginTransaction())
                {
                    User result = conn.Query<User>(@"SELECT * FROM [dbo].[user] WHERE [id] = @id", new { id }, transaction: t).SingleOrDefault();
                    return result;
                }
            }
        }
    }
}
