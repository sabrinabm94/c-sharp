using Microsoft.AspNetCore.Mvc;
using MinhaCaixa.Model;
using MyWebApp.Repository;
using System;

namespace MyWebApp.Controllers
{
    [Route("api/[Controller]")]
    public class AgenciaController: Controller
    {
        private readonly IAgenciaRepository _agenciaRepository;
        public AgenciaController(IAgenciaRepository agenciaRepository)
        {
            _agenciaRepository = agenciaRepository;
        }

        [HttpGet("list")]
        public IActionResult list()
        {
            try
            {
                return Ok(_agenciaRepository.list());

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
                return Ok(_agenciaRepository.listById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPost("save")]
        public IActionResult save([FromBody]Agencia agencia)
        {
            try
            {
                string newAgenciaId = agencia.id;
                var registredAgencia = _agenciaRepository.listById(newAgenciaId);

                if(registredAgencia == null || registredAgencia.id != newAgenciaId)
                {
                    _agenciaRepository.save(agencia);
                    return Created("/api/agencia", agencia);
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
                return Ok(_agenciaRepository.deleteById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpDelete("delete")]
        public IActionResult delete([FromBody]Agencia agencia)
        {
            try
            {
                return Ok(_agenciaRepository.delete(agencia));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPut("update")]
        public IActionResult update([FromBody]Agencia agencia)
        {
            try
            {
                _agenciaRepository.update(agencia);
                return Created("/api/agencia", agencia);

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }
    }
}
