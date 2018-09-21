using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[Controller]")]
    public class UserController : Controller
    {
        //injeção de dependências pelas interfaces
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")] //recebe json
        //localhost:57320/api/user/register
        public IActionResult setUser([FromBody]User user)
        {
            try
            {
                _userRepository.save(user);
                return Created("/api/user", user);
            }
            catch (Exception ex)
            {
                return BadRequest("Error!: " + ex.Message);
            }
        }

        [HttpGet("search={id:int}")]
        //localhost:57320/api/user/search=1
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userRepository.getById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest("Error!: " + ex.Message);
            }
        }
    }
}



