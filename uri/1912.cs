using System;

namespace Treinamento
{
    class Program
    {
        static void Main(string[] args)
        {
            string primeiraLinha = Console.ReadLine();
            string[] entrada1 = primeiraLinha.Split(' ');
            int N = Convert.ToInt32(entrada1[0]); //quantidade de tiras
            double A = Convert.ToInt32(entrada1[1]); //soma das áreas da tiras deve ser igual a A
            double comprimentoTira = 0;
            double somaAreaTotal = 0; //soma da área que deve ser igual a A

            if (N != 0 || A != 0)
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
                }
                else if(somaAreaTotal > A)
                {
                    double alturaCorte = (alturaMaxima + alturaMinima) / 2.0;
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
                        var result = String.Format("{0:N4}", alturaCorte);
                        Console.WriteLine(result);
                    }

                    /*
                     Caso 1
                     5 - 3 - 6 - 2 - 3 = 1
                     4 - 3 - 4 - 2 - 3 = 16
                     1 - 0 - 2 - 0 - 0 = 3
                     Deve remover 3 de todo o array
                     Deve ver a altura maxima para poder remover 3

                     Caso 2
                     6 - 8 - 10 - 11 - 12 - 15 - 16 = 78
                     6 - 8 - 8,8 - 8,8 - 8,8 - 8,8 - 8,8 = 58
                     0 - 0 - 1,2 - 2,2 - 3,2 - 6,2 - 7,2 = 20
                     Deve remover 20 de todo o array
                     deve ter altura maxima 8,8 para remover 20
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
