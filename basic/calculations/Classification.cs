using System;

public class Concept
{
    public String Classification(double mean)
    {
        String concept = "";

        if (mean >= 9.0)
        {
            concept = "A";
        }
        else if (mean >= 7.5 && mean < 9.0)
        {
            concept = "B";
        }
        else if (mean >= 6.0 && mean < 7.5)
        {
            concept = "C";
        }
        else if (mean >= 4.0 && mean < 6.0)
        {
            concept = "D";
        }
        else if (mean < 4.0)
        {
            concept = "E";
        }

        return concept;
    }
}
