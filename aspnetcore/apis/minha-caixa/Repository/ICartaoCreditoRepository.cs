using MinhaCaixa.Model;
using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface ICartaoCreditoRepository
    {
        List<CartaoCredito> list();
        Agencia listById(int id);
        Agencia save(CartaoCredito cartaoCredito);
        Agencia deleteById(int id);
        Agencia delete(CartaoCredito cartaoCredito);
        Agencia update(CartaoCredito cartaoCredito);
    }
}