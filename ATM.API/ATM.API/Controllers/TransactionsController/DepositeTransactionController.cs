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
        public IActionResult Deposit(TransactionDto transactionDto)
        {
            var transaction = transactionManager.Deposit(transactionDto);
            var account = accountRepo.GetAccountById(transactionDto.CardNumber, transactionDto.Pin);

            return Ok($"Deposit of {transaction?.CardNumber} successful. New balance: {account?.Balance}");

        }
    }
}
