using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Repository;
using System;

namespace MyWebApp.Controllers
{
    [Route("api/[Controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet("list")]
        public IActionResult listAll()
        {
            try
            {
                return Ok(_accountRepository.list());

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpGet("list/{id:int}")]
        public IActionResult list(int id)
        {
            try
            {
                return Ok(_accountRepository.listById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpPost("register")]
        public IActionResult save([FromBody]Account account)
        {
            try
            {
                _accountRepository.save(account);
                return Created("/api/account", account);

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpDelete("delete/{id:int}")]
        public IActionResult delete(int id)
        {
            try
            {
                return Ok(_accountRepository.removeById(id));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody]Account account)
        {
            try
            {
                return Ok(_accountRepository.remove(account));

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }
    }
}
