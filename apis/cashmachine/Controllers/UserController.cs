using Microsoft.AspNetCore.Mvc;
using MyWebApp.Repository;
using System;

namespace MyWebApp.Controllers
{
    [Route("api/[Controller]")]
    public class UserController: Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("list")]
        public IActionResult ListAll()
        {
            try
            {
                return Ok(_userRepository.list());

            } catch(Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpGet("list/{id:int}")]
        public IActionResult List(int id)
        {
            try
            {
                return Ok(_userRepository.listById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPost("register")]
        public IActionResult Save([FromBody]User user)
        {
            try
            {
                _userRepository.save(user);
                return Created("/api/user", user);
            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpDelete("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_userRepository.removeById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }
    }
}
