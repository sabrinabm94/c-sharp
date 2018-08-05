using System;

public class CheckingAccount //uma classe define a estrutura que os objetos desta classe devem seguir
{
    public string accountHolder;
    public int agencyNumber;
    public int accountNumber;
    public double accountBalance;

    public Boolean MoneyDraft(double value)
    {
        if(this.accountBalance > value)
        {
            this.accountBalance -= value;
            return true;
        } else
        {
            return false;
        }
    }
}