using System.Collections.Generic;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface IUserRepository
    {
        List<User> List();
        User getById(int Id);
        void save(User user);
    }
}