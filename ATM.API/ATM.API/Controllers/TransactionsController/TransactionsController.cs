﻿using ATM.BLL;
using ATM.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATM.API.Controllers.TransactionsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {

        private readonly ITransactionManager transactionManager;
        private readonly IAccountsRepo accountRepo;

        public TransactionsController(ITransactionManager transactionManager , IAccountsRepo accountRepo )
        {
            this.transactionManager = transactionManager;
            this.accountRepo = accountRepo;
        }


        [HttpPost]
        public IActionResult Withdrow(TransactionDto transactionDto)
        {
            var transaction = transactionManager.withdraw(transactionDto);
            var account = accountRepo.GetAccountById(transactionDto.CardNumber, transactionDto.Pin);
            
            return Ok($"Withdrawal of {transaction?.CardNumber} successful. New balance: {account?.Balance}");

        }


        
    }
}