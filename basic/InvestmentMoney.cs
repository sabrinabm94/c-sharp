namespace InvestmentMoney
{
    class InvestmentMoney
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Starting...");

            double investmentMoney = 100.00;
            double investmentFactor = 0.0036; //0.36% por mês
            int monthCounter = 1;

            /*
            com for
            for (monthCounter = 1; monthCounter < 12; monthCounter++)
            {
                if (monthCounter <= 12)
                {
                    investmentMoney = investmentMoney + investmentMoney * investmentFactor;
                    Console.WriteLine("In " + monthCounter + " month(s) you going to have: " + investmentMoney);
                }
            }
            */

            /*
            com while
            somente inicia a repetição quando uma condição for verdadeira, e não inicia ou finaliza quando for falsa
            <, >, <=, >=, ==, !=, &&, ||
            */
            while(monthCounter <= 12) {
                if (monthCounter <= 12)
                {
                    investmentMoney = investmentMoney + investmentMoney * investmentFactor;
                    Console.WriteLine("In " + monthCounter + " month(s) you going to have: " + investmentMoney);

                    //monthCounter = monthCounter + 1;
                    monthCounter += 1;
                }
            }
            
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
