using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConnectionTestAPI.Contexts;
using ConnectionTestAPI.Classes;

namespace ConnectionTestAPI.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private AccountContext _context;

        public AccountController(AccountContext context)
        {
            _context = context;

        }

        // POST api/values
        [HttpPost]
        public IActionResult AddAccount([FromBody]Account account)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Account model was invalid.");
            }

            _context.Accounts.Add(account);
            _context.SaveChanges();

            return Ok($"Account created. Account ID is {account.Id} and name is {account.Name}.");
        }        
    }
}
