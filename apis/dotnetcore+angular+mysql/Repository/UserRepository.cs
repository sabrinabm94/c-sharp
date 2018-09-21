using System.Collections.Generic;
using System.Linq;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public User getById(int id)
        {
        return _context.Users.Where(p => p.id == id).FirstOrDefault(); ;
        }

        public List<User> List()
        {
            return _context.Users.ToList();
        }

        //salva usuário no banco de dados
        public void save(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
    