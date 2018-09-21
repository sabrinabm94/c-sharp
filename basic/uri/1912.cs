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
            double somaAreaTotal = 0; //soma da área que deve ser igual a A

            string primeiraLinha = Console.ReadLine();
            string[] entrada1 = primeiraLinha.Split(' ');
            int N = Convert.ToInt32(entrada1[0]); //quantidade de tiras
            double A = Convert.ToInt32(entrada1[1]); //soma das áreas da tiras deve ser igual a A
            double comprimentoTira = 0;

            if(N != 0 || A != 0)
            {
                double[] vetorAreaBarras = new double[N];
                string segundaLinha = Console.ReadLine();
                string[] entrada2 = segundaLinha.Split(' ');

                for (int i = 0; i < N; i++)
                {
                    // comprimento cada tira
                    comprimentoTira = Convert.ToInt32(entrada2[i]);
                    vetorAreaBarras[i] = comprimentoTira;

                    //soma total das áreas das tiras
                    somaAreaTotal = somaAreaTotal + vetorAreaBarras[i]; 
                }

                ordenarDecrescente(vetorAreaBarras);
                //após ordenado descrescente define maior e menor valor
                double alturaMaxima = vetorAreaBarras[0];
                double alturaMinima = vetorAreaBarras[vetorAreaBarras.Length-1];

                if (somaAreaTotal == A)
                {
                    Console.WriteLine(":D\n"); //área total = área corte
                }
                else if (somaAreaTotal < A)
                {
                    Console.WriteLine("-.-\n"); //área total menor que a área corte
                } else if(somaAreaTotal > A)
                {                  
                    //média do corte
                    double alturaCorte = (alturaMaxima + alturaMinima) / 2;
                    
                    //resto do corte
                    double restoCorte = 0;
                    double somaAreaTotalNova = 0;

                    for (int i = 0; i < vetorAreaBarras.Length; i++)
                    {
                        if (vetorAreaBarras[i] > alturaCorte)
                        {
                            restoCorte = restoCorte + (vetorAreaBarras[i] - alturaCorte);
                            vetorAreaBarras[i] = alturaCorte;
                        }

                        somaAreaTotalNova = somaAreaTotalNova + vetorAreaBarras[i];
                    }

                    if(somaAreaTotalNova == somaAreaTotal - A)
                    {

                        Console.WriteLine(alturaCorte + ".0000");
                    }

                    /*
                     5 - 3 - 6 - 2 - 3 = 1
                     4 - 3 - 4 - 2 - 3 = 16
                     1 - 0 - 2 - 0 - 0 = 3

                     deve remover 3 de todo o array
                     deve ver a altura maxima para poder remover 3
                    */
                }
            }
            else
            {
                //Console.WriteLine("Valores inválidos!");
            }

            Console.WriteLine("Pressione enter para encerrar...");
            Console.ReadLine();
        }

        static void ordenarDecrescente(double[] vet)
        {
            for (int i = 1; i < vet.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (vet[i] > vet[j])
                    {
                        double temp = vet[i];
                        vet[i] = vet[j];
                        vet[j] = temp;
                    }
                }
            }
        }
    }
}
