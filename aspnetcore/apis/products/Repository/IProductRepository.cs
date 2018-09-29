using System.Collections.Generic;
using MyWebApp.Models;

namespace MyWebApp.Repository
{
    public interface IProductRepository
    {
        List<Product> listProducts();

        Product listProductById(int id);

        void saveProduct(Product product);

        Product removeProductById(int id);
    }
}