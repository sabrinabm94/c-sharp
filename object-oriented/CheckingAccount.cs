using System;
using Bank;

namespace Bank
{
    public class CheckingAccount
    //uma classe define a estrutura que os objetos desta classe devem seguir
    //método não tem nenhum parâmetro, deve começar sempre com letra maiúscula e não tem retorno, define uma maneira de fazer algo
    {
        public Client client;
        public int account;
        public int agency;
        public double balance;

        public Boolean Draft(double value)
        {
            if (this.balance > value)
            {
                this.balance -= value;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Deposit(double value)
        {
            this.balance += value;
        }

        public Boolean Transfer(double value, CheckingAccount targetAccount)
        {
            if (this.balance < value)
            {
                return false;
            }
            else
            {
                this.balance -= value;
                targetAccount.Deposit(value);
                return true;
            }
        }
    }
}