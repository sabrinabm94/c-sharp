using MyWebApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApp.Repository
{
    public class AgenciaRepository : IAgenciaRepository
    {
        private readonly Context _context;

        public AgenciaRepository(Context context)
        {
            _context = context;
        }

        public List<Agencia> list()
        {
            return _context.Agencias.ToList();
        }

        public Agencia listById(int id)
        {
            return _context.Agencias.FirstOrDefault(p => p.id == id);
        }

        public Agencia save(Agencia agencia)
        {
            _context.Agencias.Add(agencia);
            _context.SaveChanges();

            return agencia;
        }

        public Agencia deleteById(int id)
        {
            var agencia = _context.Agencias.FirstOrDefault(p => p.id == id);
            _context.Agencias.Remove(agencia);
            _context.SaveChanges();
            return agencia;
        }

        public Agencia delete(Agencia agencia)
        {
            _context.Agencias.Remove(agencia);
            _context.SaveChanges();
            return agencia;
        }

        public Agencia update(Agencia agencia)
        {
            _context.Update(agencia);
            _context.SaveChanges();
            return agencia;
        }
    }
}
