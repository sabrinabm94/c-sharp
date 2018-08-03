namespace InvestmentMoneyPerYear
{
    class InvestmentMoneyPerYear
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Starting...");

            double investmentMoney = 100.00;
            double investmentFactor = 0.0036; //0.36% por mês
            int yearCounter;
            int monthCounter;
            
            for (yearCounter = 1; yearCounter <= 4; yearCounter++)
            {
                for (monthCounter = 1; monthCounter <= 12; monthCounter++)
                {
                    investmentMoney *= investmentFactor;
                }

                investmentFactor += 0.0010;
            }
            Console.WriteLine("In " + yearCounter + " year(s) you going to have: " + investmentMoney);

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
