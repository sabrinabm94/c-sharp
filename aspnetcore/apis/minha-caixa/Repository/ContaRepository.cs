using MyWebApp.Model;
using System.Collections.Generic;
using System.Linq;

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
            return _context.contas.ToList();
        }

        public Conta listById(int id)
        {
            return _context.contas.FirstOrDefault(p => p.ContaCodigo == id);
        }

        public Conta save(Conta conta)
        {
            _context.contas.Add(conta);
            _context.SaveChanges();

            return conta;
        }

        public Conta deleteById(int id)
        {
            var conta = _context.contas.FirstOrDefault(p => p.ContaCodigo == id);
            _context.contas.Remove(conta);
            _context.SaveChanges();
            return conta;
        }

        public Conta delete(Conta conta)
        {
            _context.contas.Remove(conta);
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
