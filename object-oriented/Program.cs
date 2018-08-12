using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Client Sabrina = new Client();
            CheckingAccount account = new CheckingAccount();
            Sabrina.name = "Sabrina";
            account.agency = 1;
            account.account = 123456;
            account.balance = 100;

            Console.WriteLine("Account holder: " + Sabrina.name);
            Console.WriteLine("Agency number: "+ account.agency);
            Console.WriteLine("Account number: " + account.account);
            Console.WriteLine("Account balance: " + account.balance);

            account.Draft(50);
            Console.WriteLine("Account balance: " + account.balance);

            account.Deposit(1);
            Console.WriteLine("Account balance: " + account.balance);

            Client Alexander = new Client();
            CheckingAccount targetAccount = new CheckingAccount();
            Alexander.name = "Alexander";
            bool transferResult = account.Transfer(1, targetAccount);
            Console.WriteLine("The result of the money transfer is: " + transferResult);
            Console.WriteLine("Target account balance: " + targetAccount.balance);

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();

        }
    }
}
