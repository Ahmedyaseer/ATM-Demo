using ATM.BLL;
using ATM.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATM.API.Controllers.TransactionsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsControllerDeposit : ControllerBase
    {

        private readonly ITransactionManager transactionManager;
        private readonly IAccountsRepo accountRepo;

        public TransactionsControllerDeposit(ITransactionManager transactionManager, IAccountsRepo accountRepo)
        {
            this.transactionManager = transactionManager;
            this.accountRepo = accountRepo;
        }

        [HttpPost]
        public IActionResult Deposit(TransactionDto transactionDto)
        {
            var transaction = transactionManager.Deposit(transactionDto);
            var account = accountRepo.GetAccountById(transactionDto.CardNumber, transactionDto.Pin);

            return Ok($"Deposit of {transaction?.CardNumber} successful. New balance: {account?.Balance}");

        }
    }
}
