using MinhaCaixa.Model;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace MyWebApp.Repository
{
    public class TipoContaRepository : ITipoContaRepository
    {
        private readonly Context _context;

        public TipoContaRepository(Context context)
        {
            _context = context;
        }

        public List<TipoConta> list()
        {
            return _context.tipoContas.ToList();
        }

        public TipoConta listById(int id)
        {
            return _context.tipoContas.FirstOrDefault(p => p.id == id);
        }

        public TipoConta save(TipoConta tipoConta)
        {
            _context.tipoContas.Add(tipoConta);
            _context.SaveChanges();

            return tipoConta;
        }

        public TipoConta deleteById(int id)
        {
            var tipoConta = _context.tipoContas.FirstOrDefault(p => p.id == id);
            _context.tipoContas.Remove(tipoConta);
            _context.SaveChanges();
            return tipoConta;
        }

        public TipoConta delete(TipoConta tipoConta)
        {
            _context.tipoContas.Remove(tipoConta);
            _context.SaveChanges();
            return tipoConta;
        }

        public TipoConta update(TipoConta tipoConta)
        {
            _context.Update(tipoConta);
            _context.SaveChanges();
            return tipoConta;
        }
    }
}
