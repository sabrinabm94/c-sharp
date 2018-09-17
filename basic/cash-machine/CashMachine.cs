using System;
using System.Collections;
using System.Collections.Generic;

public class CashMachine
{
    public void SortMoneyBill(double[] moneyBill) //ordena as notas para descrescente
    {
        int i, j;
        double helper;
        for (i = 0; i < moneyBill.Length; i++)
        {
            for (j = 0; j < moneyBill.Length - 1; j++)
            {
                if (moneyBill[j] < moneyBill[j + 1])
                {
                    helper = moneyBill[j];
                    moneyBill[j] = moneyBill[j + 1];
                    moneyBill[j + 1] = helper;
                }
            }
        }
    }

    public void MoneyDraft(double[] moneyBill, double value)
    {
        int[] moneyBillQuantity = new int[10];
        double valueMoneyDraft = value;
        double remainder = 0;

        Console.WriteLine("");
        Console.WriteLine("Money draft with the value: " + valueMoneyDraft);

        //se o valor da retirada for impar, tenta tirar o 5 primeiro

        for (var i = 0; i < moneyBill.Length; i++)
        {
            if (value == moneyBill[i])
            { //se o valor do saque for igual ao value da nota
                moneyBillQuantity[i] += 1;
                value -= moneyBill[i];
            }
            else if (value >= moneyBill[i])
            { //se o valor do saque for maior ou igual o da nota, adiciona essa nota para ser sacada
                if (valueMoneyDraft / 2 != 0 && valueMoneyDraft < 5)
                {
                    Console.Write("Impar");
                    Console.Write(moneyBillQuantity[5]);
                    moneyBillQuantity[i] += 1;
                    value -= 5;
                }
                else
                {
                    moneyBillQuantity[i] += 1;
                    value -= moneyBill[i];
                }

            }
        }

        if (valueMoneyDraft - value != 0)
        {
            remainder = value;
            for (var j = 0; j < moneyBill.Length; j++)
            {
                if (remainder == moneyBill[j])
                { //se o value do saque for igual ao value da nota
                    moneyBillQuantity[j] += 1;
                    remainder -= moneyBill[j];
                }
                else if (remainder >= moneyBill[j])
                { //se o value do saque for maior ou igual o da nota, adiciona essa nota para ser sacada
                    moneyBillQuantity[j] += 1;
                    remainder -= moneyBill[j];
                }
            }
        }
        else
        {
            remainder = value;
        }

        if (remainder > 0)
        {
            Console.WriteLine("Não há notas disponíveis para retirar o valor inserido");
        }

        for (var i = 0; i < moneyBill.Length; i++)
        {
            Console.WriteLine("Money bill: " + moneyBill[i]);
            Console.WriteLine("Quantity of money bill: " + moneyBillQuantity[i]);
            Console.WriteLine("");
        }
        Console.WriteLine("Remainder: " + remainder);
    }
}
