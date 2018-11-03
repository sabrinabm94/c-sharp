using System.Collections.Generic;
using MyWebApp.Models;

namespace MyWebApp.Repository
{
    public interface IProductRepository
    {
        List<Product> list();

        Product listById(int id);

        Product save(Product product);

        Product deleteById(int id);

        Product delete(Product product);

        Product update(Product product);
    }
}