﻿



using ATM.BLL.DTOs.AccountsDto;
using ATM.DAL.Models.Accounts;
using ATM.DAL.Repos.Accounts;

namespace ATM.BLL.Manager.AccountsManager
{



    public class AccountManager : IAccountManager
    {
        private readonly IAccountRepo accountRepo;

        public AccountManager(IAccountRepo accountRepo)
        {
            this.accountRepo = accountRepo;
        }
        public AccountsDto Login(string cardNumber )
        {
            Account? account = accountRepo.GetAccountById(cardNumber);
            if (account == null)
            {
                throw new Exception("Account not found");
            }
            return new AccountsDto
            {
                Balance = account.Balance
            };
        }
    }

}