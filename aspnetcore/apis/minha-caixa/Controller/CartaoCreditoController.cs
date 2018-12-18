using Microsoft.AspNetCore.Mvc;
using MinhaCaixa.Model;
using MyWebApp.Repository;
using System;

namespace MyWebApp.Controllers
{
    [Route("api/[Controller]")]
    public class CartaoCreditoController: Controller
    {
        private readonly ICartaoCreditoRepository _cartaoCreditoRepository;
        public CartaoCreditoController(ICartaoCreditoRepository cartaoCreditoRepository)
        {
            _cartaoCreditoRepository = cartaoCreditoRepository;
        }

        [HttpGet("list")]
        public IActionResult list()
        {
            try
            {
                return Ok(_cartaoCreditoRepository.list());

            } catch(Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpGet("list/{id:int}")]
        public IActionResult listById(int id)
        {
            try
            {
                return Ok(_cartaoCreditoRepository.listById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPost("save")]
        public IActionResult save([FromBody]CartaoCredito cartaoCredito)
        {
            try
            {
                int newCartaoCreditoId = cartaoCredito.id;
                var registredCartaoCredito = _cartaoCreditoRepository.listById(newCartaoCreditoId);

                if(registredCartaoCredito == null || registredCartaoCredito.id != newCartaoCreditoId)
                {
                    _cartaoCreditoRepository.save(cartaoCredito);
                    return Created("/api/cartaoCredito", cartaoCredito);
                }
                return Ok(null);

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpDelete("delete/{id:int}")]
        public IActionResult deleteById(int id)
        {
            try
            {
                return Ok(_cartaoCreditoRepository.deleteById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpDelete("delete")]
        public IActionResult delete([FromBody]CartaoCredito cartaoCredito)
        {
            try
            {
                return Ok(_cartaoCreditoRepository.delete(cartaoCredito));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPut("update")]
        public IActionResult update([FromBody]CartaoCredito cartaoCredito)
        {
            try
            {
                _cartaoCreditoRepository.update(cartaoCredito);
                return Created("/api/cartaoCredito", cartaoCredito);

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }
    }
}
