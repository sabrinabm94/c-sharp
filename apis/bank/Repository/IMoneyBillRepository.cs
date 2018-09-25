using MyWebApp.Models;
using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface IMoneyBillRepository
    {
        void Update(MoneyBill moneyBill);
        List<MoneyBill> List();
    }
}