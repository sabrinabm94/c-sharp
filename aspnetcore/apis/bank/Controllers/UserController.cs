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
        public IActionResult list()
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
        public IActionResult listById(int id)
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
        public IActionResult listByUsername(string username)
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

        [HttpPost("save")]
        public IActionResult save([FromBody]User user)
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
        public IActionResult deleteById(int id)
        {
            try
            {
                return Ok(_userRepository.deleteById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpDelete("delete")]
        public IActionResult delete([FromBody]User user)
        {
            try
            {
                return Ok(_userRepository.delete(user));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPut("update")]
        public IActionResult update([FromBody]User user)
        {
            try
            {
                _userRepository.update(user);
                return Created("/api/user", user);

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPost("login")]
        //http://localhost:54681/api/user/login
        public IActionResult login([FromBody]User user)
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
