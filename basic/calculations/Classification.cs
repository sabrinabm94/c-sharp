using System;

public class Concept
{
    public String Classification(double average)
    {
        String concept = "";

        if (average >= 9.0)
        {
            concept = "A";
        }
        else if (average >= 7.5 && average < 9.0)
        {
            concept = "B";
        }
        else if (average >= 6.0 && average < 7.5)
        {
            concept = "C";
        }
        else if (average >= 4.0 && average < 6.0)
        {
            concept = "D";
        }
        else if (average < 4.0)
        {
            concept = "E";
        }

        return concept;
    }
}
