using Microsoft.AspNetCore.Mvc;
using MyWebApp.Repository;
using System;

namespace MyWebApp.Controllers
{
    [Route("api/[Controller]")]
    public class GrupoController: Controller
    {
        private readonly IGrupoRepository _grupoRepository;
        public GrupoController(IGrupoRepository grupoRepository)
        {
            _grupoRepository = grupoRepository;
        }

        [HttpGet("list")]
        public IActionResult list()
        {
            try
            {
                return Ok(_grupoRepository.list());

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
                return Ok(_grupoRepository.listById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPost("save")]
        public IActionResult save([FromBody]Grupo grupo)
        {
            try
            {
                string newGrupoId = grupo.id;
                var registeredGrupo = _grupoRepository.listById(newGrupoId);

                if(registeredGrupo == null || registeredGrupo.id != newGrupoId)
                {
                    _grupoRepository.save(grupo);
                    return Created("/api/grupo", grupo);
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
                return Ok(_grupoRepository.deleteById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpDelete("delete")]
        public IActionResult delete([FromBody]Grupo grupo)
        {
            try
            {
                return Ok(_grupoRepository.delete(grupo));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPut("update")]
        public IActionResult update([FromBody]Grupo grupo)
        {
            try
            {
                _grupoRepository.update(cliente);
                return Created("/api/grupo", grupo);

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }
    }
}
