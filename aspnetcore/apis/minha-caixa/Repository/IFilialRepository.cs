using MinhaCaixa.Model;
using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface IFilialRepository
    {
        List<Filial> list();
        Filial listById(int id);
        Filial save(Filial filial);
        Filial deleteById(int id);
        Filial delete(Filial filial);
        Filial update(Filial filial);
    }
}