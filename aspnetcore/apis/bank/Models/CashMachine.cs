using MyWebApp.Models;
using System.Collections.Generic;

public class CashMachine
{
    public int id { get; set; }
    public ICollection<MoneyBill> moneyBills { get; set; }
}
