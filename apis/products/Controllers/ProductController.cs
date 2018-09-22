using Microsoft.AspNetCore.Mvc;
using MyWebApp.Repository;
using System;

namespace MyWebApp.Controllers
{
    [Route("api/[Controller]")]
    public class ProductController: Controller
    {
        private readonly IProductRepository _productRepository;
        //injeção de dependência com as interfaces que representam as abstrações
        public ProductController(IProductRepository productRepository)
        {
            //pega a instância e coloca na variável interna
            _productRepository = productRepository;
        }

        [HttpGet("test")]
        public string test()
        {
            return "Teste";
        }

        [HttpGet("list")]
        public IActionResult listAllProducts()
        {
            try
            {
                return Ok(_productRepository.listProducts());

            } catch(Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }
    }
}
