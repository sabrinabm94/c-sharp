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

            Console.WriteLine(account.accountHolder);
            Console.WriteLine(account.agencyNumber);
            Console.WriteLine(account.accountNumber);
            Console.WriteLine(account.accountBalance);

            Console.ReadLine();

        }
    }
}
