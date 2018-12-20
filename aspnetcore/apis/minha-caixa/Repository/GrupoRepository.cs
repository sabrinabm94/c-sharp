using Microsoft.EntityFrameworkCore;
using MyWebApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApp.Repository
{
    public class GrupoRepository : IGrupoRepository
    {
        private readonly Context _context;

        public GrupoRepository(Context context)
        {
            _context = context;
        }

        public List<Grupo> list()
        {
            return _context.grupos.ToList();
        }

        public Grupo listById(int id)
        {
            return _context.Grupos.FirstOrDefault(p => p.id == id);
        }

        public Grupo save(Grupo grupo)
        {
            _context.Grupos.Add(grupo);
            _context.SaveChanges();

            return grupo;
        }

        public Grupo deleteById(int id)
        {
            var grupo = _context.Grupos.FirstOrDefault(p => p.id == id);
            _context.Grupos.Remove(grupo);
            _context.SaveChanges();
            return grupo;
        }

        public Grupo delete(Grupo grupo)
        {
            _context.Grupos.Remove(grupo);
            _context.SaveChanges();
            return grupo;
        }

        public Grupo update(Grupo grupo)
        {
            _context.Update(grupo);
            _context.SaveChanges();
            return grupo;
        }
    }
}
