using System.Collections.Generic;
using MyWebApp.Models;

namespace MyWebApp.Repository
{
    public interface IProductRepository
    {
        List<Product> listProducts();
    }
}