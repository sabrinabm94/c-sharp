using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversions
{
    class Conversions
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            
            double paymentDouble = 1150.00;

            int paymentInt;
            paymentInt = (int)paymentDouble; //convertendo double to int
            
            Console.WriteLine(paymentInt);

            short shortNumber = 150; //suporta valores até 16 bits
            int mediumNumber = 1300000000; //suporta valores até 32 bits
            long largeNumber = 130000000000; //similar ao inteiro mas com suporte de até 64 bits
            
            char firstLetter = 's'; //somente aceita aspas simples, não aceita vazio, sempre tem que ter apenas 1 caractere
            Console.WriteLine(firstLetter);
            
            firstLetter = (char)61; //sinal de =
            Console.WriteLine(firstLetter);
            
            string firstText = "The year is " + 2018;
            Console.WriteLine(firstText);
            string secoundText = ""; //string pode ser vazio
            
            string oneMoreText = @"
                - one 
                - two 
                - three";
            Console.WriteLine(oneMoreText);
           
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
