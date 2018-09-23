using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface IUserRepository
    {
        List<User> list();
        User listById(int id);
        User removeById(int id);
        void save(User user);
        void Update(User user);
    }
}