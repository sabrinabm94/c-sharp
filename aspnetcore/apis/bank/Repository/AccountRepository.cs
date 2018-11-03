using MyWebApp.Models;
using System;
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

        public Account save(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();

            return account;
        }

        public Account deleteById(int id)
        {
            var account = _context.Accounts.FirstOrDefault(p => p.id == id);
            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return account;
        }

        public Account delete(Account account)
        {
            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return account;
        }

        public Account update(Account newAccount)
        {
            /*
             var oldAccount = listById(newAccount.id);
             delete(oldAccount);
             save(newAccount);
            */

            _context.Update(newAccount);
            _context.SaveChanges();
            return newAccount;
        }

        public Object updateAccounts(Account account, Account target)
        {
            _context.Update(account);
            _context.Update(target);
            _context.SaveChanges();

            var balances = new { accountBalance = account.balance, targetBalance = target.balance };

            return balances;

        }
    }
}
