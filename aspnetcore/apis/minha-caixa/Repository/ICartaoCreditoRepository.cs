using MyWebApp.Model;
using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface ICartaoCreditoRepository
    {
        List<CartaoCredito> list();
        CartaoCredito listById(int id);
        CartaoCredito save(CartaoCredito cartaoCredito);
        CartaoCredito deleteById(int id);
        CartaoCredito delete(CartaoCredito cartaoCredito);
        CartaoCredito update(CartaoCredito cartaoCredito);
    }
}