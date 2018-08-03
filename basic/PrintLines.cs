using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintLines
{
    class PrintLines
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            for(int lineCounter = 0; lineCounter < 10; lineCounter++)
            {
                for (int rowCounter = 0; rowCounter < 10; rowCounter++)
                {
                    Console.Write("*");
                    if(rowCounter >= lineCounter)
                    {
                        break;
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
