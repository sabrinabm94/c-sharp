using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //double[] notas = {100, 50, 20, 10, 5, 2}; //lista organizada
        double[] moneyBill = { 2, 5, 10, 20, 50, 100 }; //lista desorganizada

        CashMachine cashMachine = new CashMachine();
        cashMachine.sortMoneyBill(moneyBill);
        cashMachine.BankDraft(moneyBill, 150); //testando notas de maior valor
        cashMachine.BankDraft(moneyBill, 12.5); //testando decimais
        cashMachine.BankDraft(moneyBill, 1); //testando BankDraft impossível

        Console.WriteLine("Press enter to exit...");
        Console.ReadLine();
    }
}

