using MyWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        //encapsulará toda a lógica de acesso ao banco de dados
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public List<Product> list()
        {
            return _context.Products.ToList();
        }

        public Product listById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.id == id);
        }

        public Product save(Product product)
        {
            _context.Products.Add(product); //aplica as alterações na memória
            _context.SaveChanges(); //aplica as alterações da memória para o modelo no banco de dados
            return product;
        }

        public Product deleteById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.id == id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return product;
        }

        public Product delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return product;
        }

        public Product update(Product newProduct)
        {
            var oldProduct = _context.Products.FirstOrDefault(p => p.id == newProduct.id);
            _context.Products.Remove(oldProduct);
            _context.SaveChanges();

            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return newProduct;
        }
    }
}
