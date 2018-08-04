using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Average average = new Average();
        Median median = new Median();
        Classification classification = new Classification();

        //lista com total de 6 posições - par
        double[] listEven = { 1, 2, 3, 4, 5, 6 };

        double resultAverageEven = average.calculateAverage(listEven);
        Console.WriteLine("Even list");
        Console.WriteLine("Average: " + resultAverageEven);

        double resultMedianEven = median.calculateMedian(listEven);
        Console.WriteLine("Value of median: " + resultMedianEven);

        String resultClassificationEven = classification.Classification(resultMedianEven);
        Console.WriteLine("Classification: " + resultClassificationEven);
        Console.WriteLine("");

        //lista com total de 5 posições - impar 
        double[] listOdd = { 1, 2, 3, 4, 5 };

        double resultAverageOdd = average.calculateAverage(listOdd);
        Console.WriteLine("Odd list");
        Console.WriteLine("Average: " + resultAverageOdd);

        double resultMedianOdd = median.calculateMedian(listOdd);
        Console.WriteLine("Value of median: " + resultMedianOdd);

        String resultClassificationOdd = classification.Classification(resultMedianOdd);
        Console.WriteLine("Classification: " + resultClassificationOdd);
        Console.WriteLine("");

        Console.WriteLine("Press enter to exit...");
        Console.ReadLine();
    }
}
