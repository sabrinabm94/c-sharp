using Microsoft.AspNetCore.Mvc;
using MyWebApp.Model;
using MyWebApp.Repository;
using System;

namespace MyWebApp.Controllers
{
    [Route("api/[Controller]")]
    public class ClienteController: Controller
    {
        private readonly IClienteRepository _repository;
        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("teste")]
        public IActionResult teste()
        {
            return Ok(_repository.list());
        }

        [HttpGet("list")]
        public IActionResult list()
        {
            try
            {
                return Ok(_repository.list());

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
                return Ok(_repository.listById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPost("save")]
        public IActionResult save([FromBody]Cliente cliente)
        {
            try
            {
                int newClienteId = cliente.ClienteCodigo;
                var registeredCliente = _repository.listById(newClienteId);

                if(registeredCliente == null || registeredCliente.ClienteCodigo != newClienteId)
                {
                    _repository.save(cliente);
                    return Created("/api/cliente", cliente);
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
                return Ok(_repository.deleteById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpDelete("delete")]
        public IActionResult delete([FromBody]Cliente cliente)
        {
            try
            {
                return Ok(_repository.delete(cliente));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPut("update")]
        public IActionResult update([FromBody]Cliente cliente)
        {
            try
            {
                _repository.update(cliente);
                return Created("/api/cliente", cliente);

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }
    }
}
