using MyWebApp.Model;
using System.Collections.Generic;
using System.Linq;

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
            return _context.movimentos.ToList();
        }

        public Movimento listById(int id)
        {
            return _context.movimentos.FirstOrDefault(p => p.MovimentoCodigo == id);
        }

        public Movimento save(Movimento movimento)
        {
            _context.movimentos.Add(movimento);
            _context.SaveChanges();

            return movimento;
        }

        public Movimento deleteById(int id)
        {
            var movimento = _context.movimentos.FirstOrDefault(p => p.MovimentoCodigo == id);
            _context.movimentos.Remove(movimento);
            _context.SaveChanges();
            return movimento;
        }

        public Movimento delete(Movimento movimento)
        {
            _context.movimentos.Remove(movimento);
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
