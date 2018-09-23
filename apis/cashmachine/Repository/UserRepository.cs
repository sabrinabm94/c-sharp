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

        public void save(User user)
        {
            _context.Users.Add(user); 
            _context.SaveChanges();
        }

        public User removeById(int id)
        {
            var user = _context.Users.FirstOrDefault(p => p.id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public void Update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
