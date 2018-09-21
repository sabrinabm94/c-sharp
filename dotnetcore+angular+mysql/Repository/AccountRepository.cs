using System.Collections.Generic;
using System.Linq;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Context _context;

        public AccountRepository(Context context)
        {
            _context = context;
        }

        public Account getById(int id)
        {
            return _context.Accounts.FirstOrDefault(p => p.id == id);
        }

        public List<Account> List()
        {
            return _context.Accounts.ToList();
        }

        public void save(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
    }
}
    