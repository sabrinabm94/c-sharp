
namespace FluxControllAndLoops
{
    class FluxControllAndLoops
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            int firstPersonAge = 16;
            int secondPersonAge = 24;
            int quantityOfPeople = 2;
            bool over18 = secondPersonAge >= 18;

            if (firstPersonAge >= 18)
            {
                Console.WriteLine("Can enter");
            } else if(quantityOfPeople > 1 && over18 == true)
            {
                Console.WriteLine("Can enter because the second person is over 18");
            } else
            {
                Console.WriteLine("Can't enter");
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
