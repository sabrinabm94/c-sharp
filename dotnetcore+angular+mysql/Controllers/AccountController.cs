using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[Controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("register")]
        public IActionResult setUser(Account account)
        {
            try
            {
                _accountRepository.save(account);
                return Created("/api/account", account);
            }
            catch (Exception ex)
            {
                return BadRequest("Error!: " + ex.Message);
            }
        }

        [HttpGet("search={id:int}")]
        public IActionResult GetAccountById(int id)
        {
            try
            {
                var account = _accountRepository.getById(id);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest("Error!: " + ex.Message);
            }
        }
    }
}



