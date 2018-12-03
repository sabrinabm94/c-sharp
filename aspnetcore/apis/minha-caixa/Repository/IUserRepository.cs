using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface IUserRepository
    {
        List<User> list();
        User listById(int id);
        User listByUsername(string username);
        User save(User user);
        User delete(User user);
        User deleteById(int id);
        User update(User user);
    }
}