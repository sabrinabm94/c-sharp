using Microsoft.AspNetCore.Mvc;
using MyWebApp.Repository;
using System;

namespace MyWebApp.Controllers
{
    [Route("api/[Controller]")]
    public class MovimentoController: Controller
    {
        private readonly IMovimentoRepository _movimentoRepository;
        public MovimentoController(IMovimentoRepository movimentoRepository)
        {
            _movimentoRepository = movimentoRepository;
        }

        [HttpGet("list")]
        public IActionResult list()
        {
            try
            {
                return Ok(_movimentoRepository.list());

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
                return Ok(_movimentoRepository.listById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPost("save")]
        public IActionResult save([FromBody]Movimento movimento)
        {
            try
            {
                string newMovimentoId = grupo.id;
                var registeredMovimento = _movimentoRepository.listById(newMovimentoId);

                if(registeredMovimento == null || registeredMovimento.id != newMovimentoId)
                {
                    _movimentoRepository.save(movimento);
                    return Created("/api/movimento", movimento);
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
                return Ok(_movimentoRepository.deleteById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpDelete("delete")]
        public IActionResult delete([FromBody]Movimento movimento)
        {
            try
            {
                return Ok(_movimentoRepository.delete(movimento));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPut("update")]
        public IActionResult update([FromBody]Movimento movimento)
        {
            try
            {
                _movimentoRepository.update(movimento);
                return Created("/api/movimento", movimento);

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }
    }
}
