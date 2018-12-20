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
            return _context.agencias.ToList();
        }

        public Agencia listById(int id)
        {
            return _context.agencias.FirstOrDefault(p => p.AgenciaCodigo == id);
        }

        public Agencia save(Agencia agencia)
        {
            _context.agencias.Add(agencia);
            _context.SaveChanges();

            return agencia;
        }

        public Agencia deleteById(int id)
        {
            var agencia = _context.agencias.FirstOrDefault(p => p.AgenciaCodigo == id);
            _context.agencias.Remove(agencia);
            _context.SaveChanges();
            return agencia;
        }

        public Agencia delete(Agencia agencia)
        {
            _context.agencias.Remove(agencia);
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
