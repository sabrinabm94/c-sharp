using MyWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApp.Repository
{
    public class MoneyBillRepository : IMoneyBillRepository
    {
        //encapsulará toda a lógica de acesso ao banco de dados
        private readonly Context _context;

        public MoneyBillRepository(Context context)
        {
            _context = context;
        }

        public List<MoneyBill> List()
        {
            return _context.MoneyBills.ToList();
        }

        public void Update(MoneyBill moneyBill)
        {
            _context.Update(moneyBill);
            _context.SaveChanges();
        }
    }
}
