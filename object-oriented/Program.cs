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
            account.accountHolder = "Sabrina";
            account.agencyNumber = 1;
            account.accountNumber = 123456;
            account.accountBalance = 100;

            Console.WriteLine("Account holder: " + account.accountHolder);
            Console.WriteLine("Agency number: "+ account.agencyNumber);
            Console.WriteLine("Account number: " + account.accountNumber);
            Console.WriteLine("Account balance: " + account.accountBalance);

            account.MoneyDraft(50);
            Console.WriteLine("Account balance: " + account.accountBalance);

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();

        }
    }
}
