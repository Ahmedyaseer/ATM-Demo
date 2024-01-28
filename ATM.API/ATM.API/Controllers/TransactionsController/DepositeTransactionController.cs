using ATM.BLL.Manager.TransactionsManager;
using ATM.DAL.Repos.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ATM.API.Controllers.TransactionsController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepositeTransactionController : ControllerBase
    {

        private readonly ITransactionManager transactionManager;
        private readonly IAccountRepo accountRepo;

        public DepositeTransactionController(ITransactionManager transactionManager, IAccountRepo accountRepo)
        {
            this.transactionManager = transactionManager;
            this.accountRepo = accountRepo;
        }

        [HttpPost]
        [Authorize(Policy = "UserPolicy")]
        [Route("{amount}")]
        public IActionResult Deposit( decimal amount)
        {
            var idOfCurrentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid) 
            {
                var account = accountRepo.GetAccountById(idOfCurrentUser);
                var transaction = transactionManager.Deposit(idOfCurrentUser,amount);
                
                return Ok($"Deposit of {idOfCurrentUser} successful. New balance: {account?.Balance}");

            }
            return BadRequest();    

        }
    }
}
