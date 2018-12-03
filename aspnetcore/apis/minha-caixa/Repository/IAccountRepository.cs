using System;
using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface IAccountRepository
    {
        List<Account> list();
        Account listById(int id);
        Account save(Account account);
        Account deleteById(int id);
        Account delete(Account account);
        Account update(Account newAccount);
        Object updateAccounts(Account account, Account target);
    }
}