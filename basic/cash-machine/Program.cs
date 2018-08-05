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
        cashMachine.SortMoneyBill(moneyBill);
        cashMachine.MoneyDraft(moneyBill, 150); //testando notas de maior valor
        cashMachine.MoneyDraft(moneyBill, 12.5); //testando decimais
        cashMachine.MoneyDraft(moneyBill, 1); //testando MoneyDraft impossível

        Console.WriteLine("Press enter to exit...");
        Console.ReadLine();
    }
}

