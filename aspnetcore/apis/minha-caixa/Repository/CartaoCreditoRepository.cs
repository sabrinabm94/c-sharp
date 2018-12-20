using MyWebApp.Model;
using System.Collections.Generic;
using System.Linq;

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
            return _context.cartaoCreditos.ToList();
        }

        public CartaoCredito listById(int id)
        {
            return _context.cartaoCreditos.FirstOrDefault(p => p.CartaoCreditoCodigo == id);
        }

        public CartaoCredito save(CartaoCredito cartaoCredito)
        {
            _context.cartaoCreditos.Add(cartaoCredito);
            _context.SaveChanges();

            return cartaoCredito;
        }

        public CartaoCredito deleteById(int id)
        {
            var cartaoCredito = _context.cartaoCreditos.FirstOrDefault(p => p.CartaoCreditoCodigo == id);
            _context.cartaoCreditos.Remove(cartaoCredito);
            _context.SaveChanges();
            return cartaoCredito;
        }

        public CartaoCredito delete(CartaoCredito cartaoCredito)
        {
            _context.cartaoCreditos.Remove(cartaoCredito);
            _context.SaveChanges();
            return cartaoCredito;
        }

        public CartaoCredito update(CartaoCredito cartaoCredito)
        {
            _context.Update(cartaoCredito);
            _context.SaveChanges();
            return cartaoCredito;
        }
    }
}
