using MinhaCaixa.Model;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace MyWebApp.Repository
{
    public class CartaoCreditoRepository : ICartaoCreditoRepository
    {
        private readonly Context _context;

        public CartaoCreditoRepository(Context context)
        {
            _context = context;
        }

        public List<CartaoCredito> list()
        {
            return _context.CartaoCreditos.ToList();
        }

        public CartaoCredito listById(int id)
        {
            return _context.CartaoCreditos.FirstOrDefault(p => p.id == id);
        }

        public CartaoCredito save(CartaoCreditoRepository cartaoCredito)
        {
            _context.CartaoCreditos.Add(cartaoCredito);
            _context.SaveChanges();

            return cartaoCredito;
        }

        public CartaoCredito deleteById(int id)
        {
            var agencia = _context.CartaoCreditos.FirstOrDefault(p => p.id == id);
            _context.CartaoCreditos.Remove(cartaoCredito);
            _context.SaveChanges();
            return cartaoCredito;
        }

        public CartaoCredito delete(CartaoCreditoRepository cartaoCredito)
        {
            _context.CartaoCreditos.Remove(cartaoCredito);
            _context.SaveChanges();
            return account;
        }

        public CartaoCredito update(CartaoCreditoRepository cartaoCredito)
        {
            _context.Update(cartaoCredito);
            _context.SaveChanges();
            return cartaoCredito;
        }
    }
}
