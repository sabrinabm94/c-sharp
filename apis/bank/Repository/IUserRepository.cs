using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface IUserRepository
    {
        List<User> list();
        User listById(int id);
        User removeById(int id);
        User remove(User user);
        void save(User user);
        void Update(User user);
        User listByUsername(string username);
    }
}