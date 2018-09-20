using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashMachine : ControllerBase
    {
        /*
        retorno de informações Rotas 
        https://localhost:44305/api/CashMachine/getAccount/1
        */

        private IRepositoryUser<User> repositoryUser;
        private IRepositoryAccount<Account> repositoryAccount;
        public CashMachine(IRepositoryUser<User> repositoryUserConnection, IRepositoryAccount<Account> repositoryAccountConnection)
        {
            repositoryUser = repositoryUserConnection;
            repositoryAccount = repositoryAccountConnection;
        }

        [HttpGet("getAccount/{id}")]
        public Account GetAccountInfo(int accountId)
        {
            Account account = SearchAccountById(accountId);
            return account;
        }

        [HttpGet("getAccountBalance/{id}")]
        public double GetAccountBalance(int accountId)
        {
            Account account = SearchAccountById(accountId);
            return account.balance;
        }

        [HttpGet("getUser/{id}")]
        public User GetUserInfo(int userId)
        {
            User user = SearchUserById(userId);
            return user;
        }

        //retorno de informações Lógica
        public Account SearchAccountById(int accountId)
        {
            Account account = repositoryUser.FindAccountById(accountId);
            return account;
        }

        public User SearchUserById(int userId)
        {
            User user = repositoryAccount.FindUserById(userId);
            return user;
        }

        //recebimento de informações rota
        [HttpPost("draft/{value}")]
        public double Draft(int accountId, double value)
        {
            Model.Account account = SearchAccountById(accountId);

            double[] moneyBill = { 2, 5, 10, 20, 50, 100 };
            SortMoneyBill(moneyBill);

            double balance = MoneyDraft(moneyBill, value);
            account.balance = balance;

            return balance;
        }

        [HttpPost("deposit/{value}")]
        public double Deposit(int accountId, double value)
        {
            Model.Account account = SearchAccountById(accountId);

            double balance = account.balance;
            balance += value;
            account.balance = balance;

            return balance;
        }

        private void SaveChanges()
        {
            throw new NotImplementedException();
        }

        [HttpPost("transfer/{value}")]
        public double Transfer(int accountTargetId, double value)
        {
            Model.Account accountTarget = SearchAccountById(accountTargetId);
            double balance = accountTarget.balance;

            if (balance >= value)
            {
                balance -= value;
                accountTarget.balance = balance;
            }

            return balance;
        }

        public void SortMoneyBill(double[] moneyBill) //ordena as notas para descrescente
        {
            int i, j;
            double helper;
            for (i = 0; i < moneyBill.Length; i++)
            {
                for (j = 0; j < moneyBill.Length - 1; j++)
                {
                    if (moneyBill[j] < moneyBill[j + 1])
                    {
                        helper = moneyBill[j];
                        moneyBill[j] = moneyBill[j + 1];
                        moneyBill[j + 1] = helper;
                    }
                }
            }
        }

        public double MoneyDraft(double[] moneyBill, double value)
        {
            int[] moneyBillQuantity = new int[10];
            double valueMoneyDraft = value;
            double remainder = 0;

            for (var i = 0; i < moneyBill.Length; i++)
            {
                if (value == moneyBill[i])
                { //se o valor do saque for igual ao value da nota
                    moneyBillQuantity[i] += 1;
                    value -= moneyBill[i];
                }
                else if (value >= moneyBill[i])
                { //se o valor do saque for maior ou igual o da nota, adiciona essa nota para ser sacada
                    if (valueMoneyDraft / 2 != 0 && value == 6)
                    { //se o valor da retirada for impar, tenta tirar o 5 primeiro
                        moneyBillQuantity[5] += 1;
                        value -= moneyBill[5];
                    }
                    else
                    {
                        moneyBillQuantity[i] += 1;
                        value -= moneyBill[i];
                    }

                }
            }

            if (valueMoneyDraft - value != 0)
            {
                remainder = value;
                for (var j = 0; j < moneyBill.Length; j++)
                {
                    if (remainder >= moneyBill[j])
                    { //se o valor do resto for maior ou igual o da nota, adiciona essa valor para ser sacado
                        moneyBillQuantity[j] += 1;
                        remainder -= moneyBill[j];
                    }
                }
            }
            else
            {
                remainder = value;
            }

            if (remainder != 0)
            {
                value = valueMoneyDraft - remainder;
            }
            else
            {
                value = valueMoneyDraft;
            }

            return value;
        }
    }
}



