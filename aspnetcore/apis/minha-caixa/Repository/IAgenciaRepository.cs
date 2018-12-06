using MinhaCaixa.Model;
using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface IAgenciaRepository
    {
        List<Agencia> list();
        Agencia listById(int id);
        Agencia save(Agencia agencia);
        Agencia deleteById(int id);
        Agencia delete(Agencia agencia);
        Agencia update(Agencia agencia);
    }
}