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
            return _context.CartaoCreditos.ToList();
        }

        public CartaoCredito listById(int id)
        {
            return _context.CartaoCreditos.FirstOrDefault(p => p.id == id);
        }

        public CartaoCredito save(CartaoCredito cartaoCredito)
        {
            _context.CartaoCreditos.Add(cartaoCredito);
            _context.SaveChanges();

            return cartaoCredito;
        }

        public CartaoCredito deleteById(int id)
        {
            var cartaoCredito = _context.CartaoCreditos.FirstOrDefault(p => p.id == id);
            _context.CartaoCreditos.Remove(cartaoCredito);
            _context.SaveChanges();
            return cartaoCredito;
        }

        public CartaoCredito delete(CartaoCredito cartaoCredito)
        {
            _context.CartaoCreditos.Remove(cartaoCredito);
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
