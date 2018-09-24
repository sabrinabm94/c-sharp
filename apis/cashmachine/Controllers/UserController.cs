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

        [HttpGet("list/{username}")]
        public IActionResult ListByUsername(string username)
        {
            try
            {
                return Ok(_userRepository.listByUsername(username));

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
                string newUser = user.username;
                var registredUser = _userRepository.listByUsername(newUser);

                if(registredUser == null || registredUser.username != newUser)
                {
                    _userRepository.save(user);
                    return Created("/api/user", user);
                }
                return Ok(null);

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

        [HttpPost("login")]
        //http://localhost:54681/api/user/login
        public IActionResult Login([FromBody]User user)
        {
            try
            {
                var userRegistred = _userRepository.listByUsername(user.username);

                if (userRegistred != null && userRegistred.username == user.username && userRegistred.password == user.password)
                {
                    return Ok(true);
                }
                return Ok(false);

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }
    }
}
