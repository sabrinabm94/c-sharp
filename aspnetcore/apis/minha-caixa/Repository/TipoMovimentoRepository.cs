using MyWebApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApp.Repository
{
    public class TipoMovimentoRepository : ITipoMovimentoRepository
    {
        private readonly Context _context;

        public TipoMovimentoRepository(Context context)
        {
            _context = context;
        }

        public List<TipoMovimento> list()
        {
            return _context.tipoMovimentos.ToList();
        }

        public TipoMovimento listById(int id)
        {
            return _context.tipoMovimentos.FirstOrDefault(p => p.id == id);
        }

        public TipoMovimento save(TipoMovimento tipoMovimento)
        {
            _context.tipoMovimentos.Add(tipoMovimento);
            _context.SaveChanges();

            return tipoMovimento;
        }

        public TipoMovimento deleteById(int id)
        {
            var tipoMovimento = _context.tipoMovimentos.FirstOrDefault(p => p.id == id);
            _context.tipoMovimentos.Remove(tipoMovimento);
            _context.SaveChanges();
            return tipoMovimento;
        }

        public TipoMovimento delete(TipoMovimento tipoMovimento)
        {
            _context.tipoMovimentos.Remove(tipoMovimento);
            _context.SaveChanges();
            return tipoMovimento;
        }

        public TipoMovimento update(TipoMovimento tipoMovimento)
        {
            _context.Update(tipoMovimento);
            _context.SaveChanges();
            return tipoMovimento;
        }
    }
}
