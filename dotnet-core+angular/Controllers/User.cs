public class User
{
    public string name;
    public string username;
    public string password;
    public int cpf;
    public int account;

    public void setName(string name)
    {
        this.name = name;
    }
    public string getName()
    {
        return this.name;
    }

    public void setUsername(string username)
    {
        this.username = username;
    }
    public string getUsername()
    {
        return this.username;
    }

    public void setPassword(string password)
    {
        this.password = password;
    }
    public string getPassword()
    {
        return this.password;
    }

    public void setCpf(int cpf)
    {
        this.cpf = cpf;
    }
    public int getCpf()
    {
        return this.cpf;
    }

    public void setAccount(int account)
    {
        this.account = account;
    }
    public int getAccount()
    {
        return this.account;
    }
}