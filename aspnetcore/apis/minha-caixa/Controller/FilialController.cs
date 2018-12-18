using Microsoft.AspNetCore.Mvc;
using MinhaCaixa.Model;
using MyWebApp.Repository;
using System;

namespace MyWebApp.Controllers
{
    [Route("api/[Controller]")]
    public class FilialController: Controller
    {
        private readonly IFilialRepository _filialRepository;
        public FilialController(IFilialRepository filialRepository)
        {
            _filialRepository = filialRepository;
        }

        [HttpGet("list")]
        public IActionResult list()
        {
            try
            {
                return Ok(_filialRepository.list());

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
                return Ok(_filialRepository.listById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPost("save")]
        public IActionResult save([FromBody]Filial filial)
        {
            try
            {
                int newFilialId = filial.id;
                var registeredFilial = _filialRepository.listById(newFilialId);

                if(registeredFilial == null || registeredFilial.id != newFilialId)
                {
                    _filialRepository.save(filial);
                    return Created("/api/filial", filial);
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
                return Ok(_filialRepository.deleteById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpDelete("delete")]
        public IActionResult delete([FromBody]Filial filial)
        {
            try
            {
                return Ok(_filialRepository.delete(filial));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPut("update")]
        public IActionResult update([FromBody]Filial filial)
        {
            try
            {
                _filialRepository.update(filial);
                return Created("/api/filial", filial);

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }
    }
}
