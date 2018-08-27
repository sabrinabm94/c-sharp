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
            double alturaMaxima = 0.0; //altura a ser descoberta
            int somaAreaTotal = 0; //soma da área que deve ser igual a A

            string primeiraLinha = Console.ReadLine();
            string[] entrada1 = primeiraLinha.Split(' ');
            int N = Convert.ToInt32(entrada1[0]); //quantidade de tiras
            int A = Convert.ToInt32(entrada1[1]); //soma das áreas da tiras deve ser igual a A
            int comprimentoTira = 0;

            int[] vetorAreaBarras = new int[N];
            string segundaLinha = Console.ReadLine();
            string[] entrada2 = segundaLinha.Split(' ');

            if(N == 0 && A == 0)
            {
                //Console.WriteLine("Entrada inválida!");
            } else
            {
                for (int i = 0; i < N; i++)
                {
                    comprimentoTira = Convert.ToInt32(entrada2[i]); //comprimento cada tira
                    vetorAreaBarras[i] = comprimentoTira;
                    somaAreaTotal = somaAreaTotal + vetorAreaBarras[i]; //soma total de todas as áreas das barras

                    if (vetorAreaBarras[i] > alturaMaxima)
                    {
                        alturaMaxima = vetorAreaBarras[i]; //define altura máxima
                    }
                }

                if (somaAreaTotal == A)
                {
                    Console.WriteLine(":D\n"); //área total = área corte.
                }
                else if (somaAreaTotal < A)
                {
                    Console.WriteLine("-.-\n"); //área total menor que a área corte.
                }
                else
                {
                    int aux = A;
                    Console.WriteLine("\n", BuscaBinaria(aux, vetorAreaBarras, N, 0.0, alturaMaxima)); //buscar o que deve ser cortado
                }
            }

            Console.WriteLine("Pressione enter para encerrar...");
            Console.ReadLine();
        }

        static double BuscaBinaria(double somaAreaTotal, int[] vetorAreaBarras, int N, double alturaBase, double alturaMaxima)
        {
            double alturaCorte = (alturaBase + alturaMaxima) / 2.0;
            double areaCorte = 0.0;

            for (int i = 0; i < N; i++)
            {
                if (vetorAreaBarras[i] > alturaCorte) //se a area da barra for menor que a altura do corte
                {
                    areaCorte = areaCorte + (vetorAreaBarras[i] - alturaCorte); //define a area para cortar
                }
            }

            if ((alturaMaxima - alturaBase) < 0.000001)
            {
                Console.WriteLine(alturaCorte);
                return alturaCorte;
            }
            else if (areaCorte > somaAreaTotal)
            {
                return BuscaBinaria(somaAreaTotal, vetorAreaBarras, N, alturaCorte, alturaMaxima);
            }
            else if (areaCorte < somaAreaTotal)
            {
                return BuscaBinaria(somaAreaTotal, vetorAreaBarras, N, alturaBase, alturaCorte);
            }
            else
            {
                Console.WriteLine(alturaCorte);
                return alturaCorte;
            }
        }
    }
}
