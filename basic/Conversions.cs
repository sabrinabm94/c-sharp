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

            short shortNumber = 150; //suporta valores até 16 bits
            int mediumNumber = 1300000000; //suporta valores até 32 bits
            long largeNumber = 130000000000; //similar ao inteiro mas com suporte de até 64 bits

            Console.WriteLine(paymentInt);
            Console.ReadLine();
        }
    }
}