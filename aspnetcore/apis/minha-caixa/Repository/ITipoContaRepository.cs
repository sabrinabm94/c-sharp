using MyWebApp.Model;
using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface ITipoContaRepository
    {
        List<TipoConta> list();
        TipoConta listById(int id);
        TipoConta save(TipoConta tipoConta);
        TipoConta deleteById(int id);
        TipoConta delete(TipoConta tipoConta);
        TipoConta update(TipoConta tipoConta);
    }
}