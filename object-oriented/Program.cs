using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        private static void Main(string[] args)
        {
            CheckingAccount account = new CheckingAccount();
            account.holder = "Sabrina";
            account.agency = 1;
            account.account = 123456;
            account.balance = 100;

            Console.WriteLine("Account holder: " + account.holder);
            Console.WriteLine("Agency number: "+ account.agency);
            Console.WriteLine("Account number: " + account.account);
            Console.WriteLine("Account balance: " + account.balance);

            account.Draft(50);
            Console.WriteLine("Account balance: " + account.balance);

            account.Deposit(1);
            Console.WriteLine("Account balance: " + account.balance);

            CheckingAccount targetAccount = new CheckingAccount();
            targetAccount.holder = "Alexander";
            bool transferResult = account.Transfer(1, targetAccount);
            Console.WriteLine("The result of the money transfer is: " + transferResult);
            Console.WriteLine("Target account balance: " + targetAccount.balance);

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();

        }
    }
}
