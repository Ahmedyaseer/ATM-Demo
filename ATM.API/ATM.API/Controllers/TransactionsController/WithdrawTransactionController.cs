using ATM.BLL;
using ATM.BLL.DTOs.TransactionsDto;
using ATM.BLL.Manager.TransactionsManager;
using ATM.DAL;
using ATM.DAL.Repos.Accounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATM.API.Controllers.TransactionsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawTransactionController : ControllerBase
    {

        private readonly ITransactionManager transactionManager;
        private readonly IAccountRepo accountRepo;

        public WithdrawTransactionController(ITransactionManager transactionManager , IAccountRepo accountRepo )
        {
            this.transactionManager = transactionManager;
            this.accountRepo = accountRepo;
        }


        [HttpPost]
        public IActionResult Withdrow(TransactionDto transactionDto)
        {
            if (ModelState.IsValid)
            {
                var transaction = transactionManager.Withdraw(transactionDto);
                var account = accountRepo.GetAccountById(transactionDto.CardNumber);

                return Ok($"Withdrawal of {transaction?.CardNumber} successful. New balance: {account?.Balance}");

            }
            return BadRequest();

        }


        
    }
}
