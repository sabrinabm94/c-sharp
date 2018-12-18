using MinhaCaixa.Model;
using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface ITipoMovimentoRepository
    {
        List<TipoMovimento> list();
        TipoMovimento listById(int id);
        TipoMovimento save(TipoMovimento tipoMovimento);
        TipoMovimento deleteById(int id);
        TipoMovimento delete(TipoMovimento tipoMovimento);
        TipoMovimento update(TipoMovimento tipoMovimento);
    }
}