using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
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
        public IActionResult listAll()
        {
            try
            {
                return Ok(_productRepository.listProducts());

            } catch(Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpGet("list/{id:int}")]
        public IActionResult list(int id)
        {
            try
            {
                return Ok(_productRepository.listProductById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPost("register")]
        public IActionResult save([FromBody]Product product)
        {
            try
            {
                _productRepository.saveProduct(product);
                return Created("/api/product", product);

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpDelete("delete/{id:int}")]
        public IActionResult delete(int id)
        {
            try
            {
                return Ok(_productRepository.removeProductById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }
    }
}
