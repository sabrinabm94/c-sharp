using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento
{
    class Program
    {
        static void Main(string[] args)
        {
            int casos = Convert.ToInt32(Console.ReadLine());

            for (int y = 0; y < casos; y++)
            {
                string entradas = Console.ReadLine();
                string[] entrada = entradas.Split(' ');
                int totalAndares = Convert.ToInt32(entrada[0]);
                int totalCapacidadeElevador = Convert.ToInt32(entrada[1]);
                int totalPessoas = Convert.ToInt32(entrada[2]);

                string andares = Console.ReadLine();
                string[] entradaAndares = andares.Split(' ');
                List<string> andaresVisitar = new List<string>();
                andaresVisitar.AddRange(entradaAndares);

                List<int> andar = andaresVisitar.Select(s => Convert.ToInt32(s)).ToList();

                andar.Sort();
                andar.Reverse();

                bool andarValidado = true;

                for (int i = 0; i < totalPessoas; i++)
                {
                    if (andar[i] > totalAndares)
                    {
                        andarValidado = false;
                        break;
                    }
                }

                int energia = 0;
                int energiaBase = 0;

                if (andarValidado == true)
                {
                    while (andar.Count != 0)
                    {
                        energiaBase = andar[0];

                        if (andar.Count >= totalCapacidadeElevador)
                        {
                            andar.RemoveRange(0, totalCapacidadeElevador);
                        }
                        else
                        {
                            andar.RemoveRange(0, andar.Count);
                        }

                        energia += (energiaBase * 2);
                    }

                    Console.WriteLine(energia);
                }
            }
        }
    }
}