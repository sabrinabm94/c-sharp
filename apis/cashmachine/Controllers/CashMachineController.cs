using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApp.Controllers
{
    [Route("api/[Controller]")]
    public class CashMachineController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMoneyBillRepository _moneyBillRepository;
        public CashMachineController(IAccountRepository accountRepository, IMoneyBillRepository moneyBillRepository)
        {
            _accountRepository = accountRepository;
            _moneyBillRepository = moneyBillRepository;
        }

        [HttpGet("moneybills")]
        public IActionResult List()
        {
            try
            {
                return Ok(_moneyBillRepository.List());

            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpGet("deposit/accountId={id:int}&value={value:double}")]
        //localhost:54681/api/cashmachine/deposit/accountId=1&value=200
        public IActionResult Deposit(int id, double value)
        {
            try
            {
                var account = _accountRepository.listById(id);

                account.balance = account.balance + value;

                _accountRepository.UpdateBalanceAccount(account);

                return Ok(account.balance);
            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpGet("transfer/accountId={id:int}&accountTarget={idTarget:int}&value={value:double}")]
        //localhost:54681/api/cashmachine/transfer/accountId=1&accountTarget=2&value=100
        public IActionResult Transfer(int id, int idTarget, double value)
        {
            try
            {
                var account = _accountRepository.listById(id);

                if(account.balance >= value)
                {
                    var target = _accountRepository.listById(idTarget);

                    account.balance = account.balance - value;
                    target.balance = target.balance + value;

                    _accountRepository.UpdateBalanceAccounts(account, target);
                }

                return Ok(account.balance);
            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        [HttpGet("withdraw/accountId={id:int}&value={value:double}")]
        //localhost:54681/api/cashmachine/withdraw/accountId=1&value=100
        public IActionResult Withdraw(int id, double value)
        {
            try
            {
                var account = _accountRepository.listById(id);
                double balance = account.balance;

                if (balance >= value)
                {
                    account.balance = balance - MoneyDraft(value);

                    _accountRepository.UpdateBalanceAccount(account);
                }

                return Ok(account.balance); //retorna o valor sacado sem o resto que não pode ser retirado!
            }
            catch (Exception error)
            {
                return BadRequest("Error: " + error);
            }
        }

        public double MoneyDraft(double value)
        {
            double valueMoneyDraft = value;
            double remainder = 0;

            if (!_moneyBillRepository.List().Any()) //so cria se não existir
            {
                MoneyBill moneyBill100 = new MoneyBill();
                moneyBill100.value = 100.0;
                _moneyBillRepository.Update(moneyBill100);

                MoneyBill moneyBill50 = new MoneyBill();
                moneyBill50.value = 50.0;
                _moneyBillRepository.Update(moneyBill50);

                MoneyBill moneyBill20 = new MoneyBill();
                moneyBill20.value = 20.0;
                _moneyBillRepository.Update(moneyBill20);

                MoneyBill moneyBill5 = new MoneyBill();
                moneyBill5.value = 5.0;
                _moneyBillRepository.Update(moneyBill5);

                MoneyBill moneyBill2 = new MoneyBill();
                moneyBill2.value = 2.0;
                _moneyBillRepository.Update(moneyBill2);
            }

            var moneyBillsList = new List<MoneyBill>();
            foreach (var moneyBill in _moneyBillRepository.List())
            {
                moneyBillsList.Add(moneyBill);
            }

            for (var i = 0; i < moneyBillsList.Count; i++)
            {
                if (value == moneyBillsList[i].value)
                { //se o valor do saque for igual ao value da nota
                    moneyBillsList[i].quantity += 1;
                    value -= moneyBillsList[i].value;
                    _moneyBillRepository.Update(moneyBillsList[i]);
                    i = -1;
                }
                else if (value == 6)
                { //se o valor da retirada for impar, tenta tirar o 5 primeiro
                    moneyBillsList[4].quantity += 1;
                    value -= moneyBillsList[4].value;
                    _moneyBillRepository.Update(moneyBillsList[4]);
                }
                else if (value > moneyBillsList[i].value)
                { //se o valor do saque for maior, adiciona essa nota para ser sacada
                    moneyBillsList[i].quantity += 1;
                    value -= moneyBillsList[i].value;
                    _moneyBillRepository.Update(moneyBillsList[i]);
                    i = -1;
                }
            }

            if (value != 0)
            { //se valor inicial do saque - o valor atual do saque for diferente de 0: tem resto
                remainder = value;
                for (var j = 0; j < moneyBillsList.Count(); j++)
                {
                    if (remainder >= moneyBillsList[j].value)
                    { //ve se tem como tirar alguma nota com o resto
                        moneyBillsList[j].quantity += 1;
                        remainder -= moneyBillsList[j].value;
                        _moneyBillRepository.Update(moneyBillsList[j]);
                    }
                    else
                    {
                        break;
                    }
                }
                //retorna o valor de saque (o resto que sobrou não foi retirado)
                return valueMoneyDraft - remainder;

            }
            else
            { //retorna o valor de saque (foi retirado todo o valor solicitado)
                return valueMoneyDraft;
            }
        }
    }
}
