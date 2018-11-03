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

        //http://localhost:54681/api/product/test
        [HttpGet("test")]
        public string test()
        {
            return "Teste";
        }

        //http://localhost:54681/api/product/list
        [HttpGet("list")]
        public IActionResult listAll()
        {
            try
            {
                return Ok(_productRepository.list());

            } catch(Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        //http://localhost:54681/api/product/list/1
        [HttpGet("list/{id:int}")]
        public IActionResult list(int id)
        {
            try
            {
                return Ok(_productRepository.listById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        //http://localhost:54681/api/product/save
        [HttpPost("save")]
        public IActionResult save([FromBody]Product product)
        {
            try
            {
                _productRepository.save(product);
                return Created("/api/product", product);

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        //http://localhost:54681/api/product/delete
        [HttpDelete("delete")]
        public IActionResult delete([FromBody]Product product)
        {
            try
            {
                return Ok(_productRepository.delete(product));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        //http://localhost:54681/api/product/delete/1
        [HttpDelete("deleteById/{id:int}")]
        public IActionResult deleteById(int id)
        {
            try
            {
                return Ok(_productRepository.deleteById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPut("update")]
        //http://localhost:54681/api/product/update
        public IActionResult update([FromBody] Product product)
        {
            try
            {
                _productRepository.update(product);
                return Created("/api/product", product);

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }
    }
}
