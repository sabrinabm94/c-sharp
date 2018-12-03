using MyWebApp.Models;
using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface IMoneyBillRepository
    {
        void update(MoneyBill moneyBill);
        List<MoneyBill> list();
    }
}