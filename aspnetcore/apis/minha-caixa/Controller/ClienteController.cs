using Microsoft.AspNetCore.Mvc;
using MinhaCaixa.Model;
using MyWebApp.Repository;
using System;

namespace MyWebApp.Controllers
{
    [Route("api/[Controller]")]
    public class ClienteController: Controller
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("list")]
        public IActionResult list()
        {
            try
            {
                return Ok(_clienteRepository.list());

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
                return Ok(_clienteRepository.listById(id));

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
                var registeredCliente = _clienteRepository.listById(newClienteId);

                if(registeredCliente == null || registeredCliente.ClienteCodigo != newClienteId)
                {
                    _clienteRepository.save(cliente);
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
                return Ok(_clienteRepository.deleteById(id));

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
                return Ok(_clienteRepository.delete(cliente));

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
                _clienteRepository.update(cliente);
                return Created("/api/cliente", cliente);

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }
    }
}
