using System.Collections.Generic;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface IAccountRepository
    {
        List<Account> List();
        Account getById(int Id);
        void save(Account account);
    }
}