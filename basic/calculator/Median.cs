using System;
using System.Collections;
using System.Collections.Generic;

public class Median
{
    public double calculateMedian(double[] vet)
    {
        int left = 0;
        int right = vet.Length;
        double haft = 0;

        if (right % 2 == 0)
        { //método para listas pares	
            double firstHaft = (left + right) / 2;
            double secondHaft = firstHaft - 1;

            Console.WriteLine("Position of median: " + (firstHaft + secondHaft) / 2);

            return (vet[(int)firstHaft] + vet[(int)secondHaft]) / 2;
        }
        else
        { //método para listas ímpares
            haft = (left + right) / 2;
            Console.WriteLine("Position of median: " + haft);

            return vet[(int)haft];
        }
    }
}
