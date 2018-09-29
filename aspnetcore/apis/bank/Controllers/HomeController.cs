using Microsoft.AspNetCore.Mvc;
using MyWebApp.Repository;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMoneyBillRepository _moneyBillRepository;

        public HomeController(IUserRepository userRepository, IAccountRepository accountRepository, IMoneyBillRepository moneyBillRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _moneyBillRepository = moneyBillRepository;
        }

        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
