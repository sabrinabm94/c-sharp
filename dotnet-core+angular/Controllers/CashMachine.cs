using System;

public class CashMachine
{
    public double value = 0;

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

        Console.WriteLine("-------------------");
        Console.WriteLine("");
        Console.WriteLine("Money draft with the value: " + valueMoneyDraft);
        Console.WriteLine("");

        for (var i = 0; i < moneyBill.Length; i++)
        {
            if (value == moneyBill[i])
            { //se o valor do saque for igual ao value da nota
                moneyBillQuantity[i] += 1;
                value -= moneyBill[i];
            }
            else if (value >= moneyBill[i])
            { //se o valor do saque for maior ou igual o da nota, adiciona essa nota para ser sacada
                if (valueMoneyDraft / 2 != 0 && value == 6)
                { //se o valor da retirada for impar, tenta tirar o 5 primeiro
                    moneyBillQuantity[5] += 1;
                    value -= moneyBill[5];
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
                if (remainder >= moneyBill[j])
                { //se o valor do resto for maior ou igual o da nota, adiciona essa valor para ser sacado
                    moneyBillQuantity[j] += 1;
                    remainder -= moneyBill[j];
                }
            }
        }
        else
        {
            remainder = value;
        }

        for (var i = 0; i < moneyBill.Length; i++)
        {
            Console.WriteLine("Money bill: " + moneyBill[i]);
            Console.WriteLine("Quantity of money bill: " + moneyBillQuantity[i]);
            Console.WriteLine("");
        }

        if (remainder != 0)
        {
            Console.WriteLine("Invalid value for the remainder: " + remainder);
            setValue(valueMoneyDraft-remainder);
        } else
        {
            Console.WriteLine("All value was removed.");
            setValue(valueMoneyDraft);
        }
        Console.WriteLine("");
    }

    public void setValue(double value)
    {
        this.value = value;
    }
    public double getValue()
    {
        return this.value;
    }

    public void setAccountInfo(Account account)
    {
        account.Draft(getValue());
    }
}
