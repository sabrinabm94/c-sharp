using MyWebApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApp.Repository
{
    public class FilialRepository : IFilialRepository
    {
        private readonly Context _context;

        public FilialRepository(Context context)
        {
            _context = context;
        }

        public List<Filial> list()
        {
            return _context.filiais.ToList();
        }

        public Filial listById(int id)
        {
            return _context.filiais.FirstOrDefault(p => p.FilialCodigo == id);
        }

        public Filial save(Filial filial)
        {
            _context.filiais.Add(filial);
            _context.SaveChanges();

            return filial;
        }

        public Filial deleteById(int id)
        {
            var filial = _context.filiais.FirstOrDefault(p => p.FilialCodigo == id);
            _context.filiais.Remove(filial);
            _context.SaveChanges();
            return filial;
        }

        public Filial delete(Filial filial)
        {
            _context.filiais.Remove(filial);
            _context.SaveChanges();
            return filial;
        }

        public Filial update(Filial filial)
        {
            _context.Update(filial);
            _context.SaveChanges();
            return filial;
        }
    }
}
