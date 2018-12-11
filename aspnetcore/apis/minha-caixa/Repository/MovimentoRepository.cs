using MinhaCaixa.Model;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace MyWebApp.Repository
{
    public class MovimentoRepository : IMovimentoRepository
    {
        private readonly Context _context;

        public MovimentoRepository(Context context)
        {
            _context = context;
        }

        public List<Movimento> list()
        {
            return _context.Movimentos.ToList();
        }

        public Movimento listById(int id)
        {
            return _context.Movimentos.FirstOrDefault(p => p.id == id);
        }

        public Movimento save(Movimento movimento)
        {
            _context.Movimentos.Add(movimento);
            _context.SaveChanges();

            return movimento;
        }

        public Movimento deleteById(int id)
        {
            var movimento = _context.Movimentos.FirstOrDefault(p => p.id == id);
            _context.Movimentos.Remove(movimento);
            _context.SaveChanges();
            return movimento;
        }

        public Movimento delete(Movimento movimento)
        {
            _context.Movimentos.Remove(movimento);
            _context.SaveChanges();
            return movimento;
        }

        public Movimento update(Movimento movimento)
        {
            _context.Update(movimento);
            _context.SaveChanges();
            return movimento;
        }
    }
}
