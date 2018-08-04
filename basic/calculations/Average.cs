using System;

public class Mean
{
    public double calculateMean(double[] vet)
    {
        double sum = 0;

        for (int i = 0; i < vet.Length; i++)
        {
            sum += vet[i];
        }
        return sum / vet.Length;
    }
}

