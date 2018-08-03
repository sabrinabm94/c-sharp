
namespace FluxControl
{
    class FluxControl
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            int firstPersonAge = 16;
            int secondPersonAge = 24;
            int quantityOfPeople = 2;
            bool accompanied = quantityOfPeople > 1;
            bool over18 = firstPersonAge >= 18;

            if((accompanied == true && secondPersonAge >= 18) || over18 == true)
            {
                Console.WriteLine("Can enter.");
            } else
            {
                Console.WriteLine("Can't enter.");
            }

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
