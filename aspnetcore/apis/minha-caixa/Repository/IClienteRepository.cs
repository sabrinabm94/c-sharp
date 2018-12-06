using MinhaCaixa.Model;
using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface IClienteRepository
    {
        List<Cliente> list();
        Cliente listById(int id);
        Cliente save(Cliente cliente);
        Cliente deleteById(int id);
        Cliente delete(Cliente cliente);
        Cliente update(Cliente cliente);
    }
}