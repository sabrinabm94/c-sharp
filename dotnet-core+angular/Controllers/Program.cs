using System;

class Program
{
    public static void Main(string[] args)
    {
        User sabrina = new User();
        sabrina.setName("Sabrina");
        sabrina.setUsername("sabrina");
        sabrina.setPassword("sabrina123");
        sabrina.setCpf(111111);
        sabrina.setAccount(01);

        Account account01 = new Account();
        account01.balance = 100;

        User alexander = new User();
        alexander.setName("Alexander");
        alexander.setUsername("alexander");
        alexander.setPassword("alexander123");
        alexander.setCpf(2222222);
        alexander.setAccount(02);

        Account account02 = new Account();
        account02.balance = 100;

        //double[] notas = {100, 50, 20, 10, 5, 2}; //lista organizada
        double[] moneyBill = { 2, 5, 10, 20, 50, 100 }; //lista desorganizada

        CashMachine cashMachine = new CashMachine();
        cashMachine.SortMoneyBill(moneyBill);
        cashMachine.MoneyDraft(moneyBill, 11.5); //testando decimais
        cashMachine.setAccountInfo(account01);

        cashMachine.MoneyDraft(moneyBill, 6); //testando ímpares
        cashMachine.setAccountInfo(account02);

        Console.WriteLine("Accounts balance");
        Console.WriteLine(account01.balance);
        Console.WriteLine(account02.balance);

        Console.WriteLine("Press enter to exit...");
        Console.ReadLine();
    }
}

