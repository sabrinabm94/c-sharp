using Microsoft.AspNetCore.Mvc;
using MinhaCaixa.Model;
using MyWebApp.Repository;
using System;

namespace MyWebApp.Controllers
{
    [Route("api/[Controller]")]
    public class TipoMovimentoController: Controller
    {
        private readonly ITipoMovimentoRepository _TipoMovimentoRepository;
        public TipoMovimentoController(ITipoMovimentoRepository tipoMovimentoRepository)
        {
            _TipoMovimentoRepository = tipoMovimentoRepository;
        }

        [HttpGet("list")]
        public IActionResult list()
        {
            try
            {
                return Ok(_TipoMovimentoRepository.list());

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
                return Ok(_TipoMovimentoRepository.listById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPost("save")]
        public IActionResult save([FromBody]TipoMovimento tipoMovimento)
        {
            try
            {
                int tipoMovimentoId = tipoMovimento.TipoMovimentoCodigo;
                var registeredTipoMovimento = _TipoMovimentoRepository.listById(tipoMovimentoId);

                if(registeredTipoMovimento == null || registeredTipoMovimento.TipoMovimentoCodigo != tipoMovimentoId)
                {
                    _TipoMovimentoRepository.save(tipoMovimento);
                    return Created("/api/tipoMovimento", tipoMovimento);
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
                return Ok(_TipoMovimentoRepository.deleteById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpDelete("delete")]
        public IActionResult delete([FromBody]TipoMovimento tipoMovimento)
        {
            try
            {
                return Ok(_TipoMovimentoRepository.delete(tipoMovimento));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPut("update")]
        public IActionResult update([FromBody]TipoMovimento tipoMovimento)
        {
            try
            {
                _TipoMovimentoRepository.update(tipoMovimento);
                return Created("/api/tipoMovimento", tipoMovimento);

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }
    }
}
