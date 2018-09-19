public class AccountController
{
    public double balance;

    public bool Draft(double value)
    {
        if (this.balance > value)
        {
            this.balance -= value;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Deposit(double value)
    {
        this.balance += value;
    }

    public bool Transfer(double value, AccountController targetAccount)
    {
        if (this.balance < value)
        {
            return false;
        }
        else
        {
            this.balance -= value;
            targetAccount.Deposit(value);
            return true;
        }
    }
}