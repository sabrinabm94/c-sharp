using MinhaCaixa.Model;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace MyWebApp.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly Context _context;

        public ContaRepository(Context context)
        {
            _context = context;
        }

        public List<Conta> list()
        {
            return _context.Contas.ToList();
        }

        public Conta listById(int id)
        {
            return _context.Contas.FirstOrDefault(p => p.id == id);
        }

        public Conta save(Conta conta)
        {
            _context.Contas.Add(conta);
            _context.SaveChanges();

            return conta;
        }

        public Conta deleteById(int id)
        {
            var conta = _context.Contas.FirstOrDefault(p => p.id == id);
            _context.Contas.Remove(conta);
            _context.SaveChanges();
            return conta;
        }

        public Conta delete(Conta conta)
        {
            _context.Contas.Remove(conta);
            _context.SaveChanges();
            return conta;
        }

        public Conta update(Conta conta)
        {
            _context.Update(conta);
            _context.SaveChanges();
            return conta;
        }
    }
}
