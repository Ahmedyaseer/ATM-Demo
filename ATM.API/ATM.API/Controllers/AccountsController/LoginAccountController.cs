using ATM.BLL;
using ATM.BLL.Manager.AccountsManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATM.API.Controllers.AccountsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAccountController : ControllerBase
    {
        private readonly IAccountManager accountManager;
        public LoginAccountController(IAccountManager accountManager)
        {
            this.accountManager = accountManager;
        }


        [HttpPost]

        public IActionResult LoginUser(int cardNumber , int pin)
        {
            var account = accountManager.Login(cardNumber, pin);
            if(account == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);   
            }
            return Ok(new
            {
                balance = account.Balance
            });
        }
    }
}
