using MyWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Context _context;

        public AccountRepository(Context context)
        {
            _context = context;
        }

        public List<Account> list()
        {
            return _context.Accounts.ToList();
        }

        public Account listById(int id)
        {
            return _context.Accounts.FirstOrDefault(p => p.id == id);
        }

        public void save(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public Account removeById(int id)
        {
            var account = _context.Accounts.FirstOrDefault(p => p.id == id);
            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return account;
        }

        public void UpdateBalanceAccount(Account account)
        {
            _context.Update(account);
            _context.SaveChanges();
        }

        public void UpdateBalanceAccounts(Account account, Account target)
        {
            _context.Update(account);
            _context.Update(target);
            _context.SaveChanges();
        }
    }
}
