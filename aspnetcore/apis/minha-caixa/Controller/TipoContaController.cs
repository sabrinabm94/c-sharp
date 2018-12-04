using Microsoft.AspNetCore.Mvc;
using MyWebApp.Repository;
using System;

namespace MyWebApp.Controllers
{
    [Route("api/[Controller]")]
    public class TipoContaController: Controller
    {
        private readonly ITipoContaRepository _TipoContaRepository;
        public TipoContaController(ITipoContaRepository tipoContaRepository)
        {
            _TipoContaRepository = tipoContaRepository;
        }

        [HttpGet("list")]
        public IActionResult list()
        {
            try
            {
                return Ok(_TipoContaRepository.list());

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
                return Ok(_TipoContaRepository.listById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPost("save")]
        public IActionResult save([FromBody]TipoConta tipoConta)
        {
            try
            {
                string tipoContaId = grupo.id;
                var registeredTipoConta = _TipoContaRepository.listById(tipoContaId);

                if(registeredTipoConta == null || registeredTipoConta.id != tipoContaId)
                {
                    _TipoContaRepository.save(tipoConta);
                    return Created("/api/tipoConta", tipoConta);
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
                return Ok(_TipoContaRepository.deleteById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpDelete("delete")]
        public IActionResult delete([FromBody]TipoConta tipoConta)
        {
            try
            {
                return Ok(_TipoContaRepository.delete(tipoConta));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPut("update")]
        public IActionResult update([FromBody]TipoConta tipoConta)
        {
            try
            {
                _TipoContaRepository.update(tipoConta);
                return Created("/api/tipoConta", tipoConta);

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }
    }
}
