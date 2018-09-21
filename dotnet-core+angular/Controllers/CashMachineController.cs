using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[Controller]")]
    public class CashMachineController : Controller
    {
        //injeção de dependências pelas interfaces
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;

        public CashMachineController(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        [HttpGet("draft/value={value:int}&id={id:int}")]
        public IActionResult Draft(double value, int id)
        {
            try
            {
                var account = _accountRepository.getById(id);

                double[] moneyBill = { 2, 5, 10, 20, 50, 100 };
                SortMoneyBill(moneyBill);

                double balance = account.balance;
                balance = MoneyDraft(moneyBill, balance); //todo ver como retornar a quantidade de notas
                account.balance = balance;

                return Ok(account.balance);
            }
            catch (Exception ex)
            {
                return BadRequest("Error!: " + ex.Message);
            }
        }

        [HttpGet("deposit/value={value:int}&id={id:int}")]
        public IActionResult Deposit(double value, int id)
        {
            try
            {
                var account = _accountRepository.getById(id);
                double balance = account.balance;
                balance = balance += value;

                return Ok(balance);
            }
            catch (Exception ex)
            {
                return BadRequest("Error!: " + ex.Message);
            }
        }

        [HttpGet("transfer/value={value:int}&id={id:int}&target={target:int}")]
        public IActionResult Transfer(double value, int id, int target)
        {
            try
            {
                var account = _accountRepository.getById(id);
                var targetAccount = _accountRepository.getById(target);

                if(targetAccount != account)
                {
                    double balance = targetAccount.balance;

                    if (balance >= value)
                    {
                        account.balance -= value;
                        targetAccount.balance += value;
                    }

                    return Ok(value);
                } else
                {
                    return Ok(null);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error!: " + ex.Message);
            }
        }

        public void SortMoneyBill(double[] moneyBill) //ordena as notas para descrescente
        {
            int i, j;
            double helper;
            for (i = 0; i < moneyBill.Length; i++)
            {
                for (j = 0; j < moneyBill.Length - 1; j++)
                {
                    if (moneyBill[j] < moneyBill[j + 1])
                    {
                        helper = moneyBill[j];
                        moneyBill[j] = moneyBill[j + 1];
                        moneyBill[j + 1] = helper;
                    }
                }
            }
        }

        public double MoneyDraft(double[] moneyBill, double value)
        {
            int[] moneyBillQuantity = new int[10];
            double valueMoneyDraft = value;
            double remainder = 0;

            for (var i = 0; i < moneyBill.Length; i++)
            {
                if (value == moneyBill[i])
                { //se o valor do saque for igual ao value da nota
                    moneyBillQuantity[i] += 1;
                    value -= moneyBill[i];
                }
                else if (value >= moneyBill[i])
                { //se o valor do saque for maior ou igual o da nota, adiciona essa nota para ser sacada
                    if (valueMoneyDraft / 2 != 0 && value == 6)
                    { //se o valor da retirada for impar, tenta tirar o 5 primeiro
                        moneyBillQuantity[5] += 1;
                        value -= moneyBill[5];
                    }
                    else
                    {
                        moneyBillQuantity[i] += 1;
                        value -= moneyBill[i];
                    }

                }
            }

            if (valueMoneyDraft - value != 0)
            {
                remainder = value;
                for (var j = 0; j < moneyBill.Length; j++)
                {
                    if (remainder >= moneyBill[j])
                    { //se o valor do resto for maior ou igual o da nota, adiciona essa valor para ser sacado
                        moneyBillQuantity[j] += 1;
                        remainder -= moneyBill[j];
                    }
                }
            }
            else
            {
                remainder = value;
            }

            if (remainder != 0)
            {
                value = valueMoneyDraft - remainder;
            }
            else
            {
                value = valueMoneyDraft;
            }

            return value;
        }
    }
}



