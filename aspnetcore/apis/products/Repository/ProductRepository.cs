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

        public List<Product> listProducts()
        {
            return _context.Products.ToList();
        }

        public Product listProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.id == id);
        }

        public void saveProduct(Product product)
        {
            _context.Products.Add(product); //aplica as alterações na memória
            _context.SaveChanges(); //aplica as alterações da memória para o modelo no banco de dados
        }

        public Product removeProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.id == id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return product;
        }
    }
}
