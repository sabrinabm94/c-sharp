using MyWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApp.Repository
{
    public class UserRepository : IUserRepository
    {
        //encapsulará toda a lógica de acesso ao banco de dados
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public List<User> list()
        {
            return _context.Users.ToList();
        }

        public User listById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.id == id);
        }

        public User listByUsername(string username)
        {
            return _context.Users.FirstOrDefault(p => p.username == username);
        }

        public User save(User user)
        {
            _context.Users.Add(user); 
            _context.SaveChanges();

            return user;
        }

        public User delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public User deleteById(int id)
        {
            var user = _context.Users.FirstOrDefault(p => p.id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public User update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();

            return user;
        }
    }
}
