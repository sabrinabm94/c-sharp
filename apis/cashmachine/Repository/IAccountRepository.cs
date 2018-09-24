﻿using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface IAccountRepository
    {
        List<Account> list();
        Account listById(int id);
        Account removeById(int id);
        void save(Account account);
        void UpdateBalanceAccounts(Account account, Account target);
        void UpdateBalanceAccount(Account account);
    }
}