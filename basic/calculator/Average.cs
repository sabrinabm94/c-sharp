using System;

public class Average
{
    public double calculateAverage(double[] vet)
    {
        double sum = 0;

        for (int i = 0; i < vet.Length; i++)
        {
            sum += vet[i];
        }
        return sum / vet.Length;
    }
}

