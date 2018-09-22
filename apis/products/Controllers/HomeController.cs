using Microsoft.AspNetCore.Mvc;
using MyWebApp.Repository;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        //declarando repositórios no construtor do controller
        private readonly IProductRepository _productRepository;
        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View(_productRepository.listProducts());
        }

        public string test()
        {
            return "Test!";
        }
    }
}
