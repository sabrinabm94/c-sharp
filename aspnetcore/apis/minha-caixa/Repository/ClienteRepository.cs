using MyWebApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApp.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly Context _context;

        public ClienteRepository(Context context)
        {
            _context = context;
        }

        public List<Cliente> list()
        {
            return _context.clientes.ToList();
        }

        public Cliente listById(int id)
        {
            return _context.clientes.FirstOrDefault(p => p.ClienteCodigo == id);
        }

        public Cliente save(Cliente cliente)
        {
            _context.clientes.Add(cliente);
            _context.SaveChanges();

            return cliente;
        }

        public Cliente deleteById(int id)
        {
            var cliente = _context.clientes.FirstOrDefault(p => p.ClienteCodigo == id);
            _context.clientes.Remove(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public Cliente delete(Cliente cliente)
        {
            _context.clientes.Remove(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public Cliente update(Cliente cliente)
        {
            _context.Update(cliente);
            _context.SaveChanges();
            return cliente;
        }
    }
}
