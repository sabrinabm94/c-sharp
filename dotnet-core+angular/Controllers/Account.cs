public class Account
{
    public int id;
    public double balance;
    public int userId;

    public bool Draft(double value)
    {
        balance = getBalance();
        if (this.balance > value)
        {
            this.balance -= value;
            setBalance(this.balance);
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
        setBalance(this.balance);
    }

    public bool Transfer(double value, Account targetAccount)
    {
        balance = getBalance();
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

    public void setId(int id)
    {
        this.id = id;
    }
    public int getId()
    {
        return this.id;
    }

    public void setBalance(double balance)
    {
        this.balance = balance;
    }
    public double getBalance()
    {
        return this.balance;
    }

    public void setUserId(int userId)
    {
        this.userId = userId;
    }
    public int getUserId()
    {
        return this.userId;
    }

}