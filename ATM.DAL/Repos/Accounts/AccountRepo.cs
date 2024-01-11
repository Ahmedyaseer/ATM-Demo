﻿

using ATM.DAL.Models.Accounts;
using ATM.DAL.DatabaseContext;

namespace ATM.DAL.Repos.Accounts
{



    public class AccountRepo : IAccountRepo
    {
        private readonly AtmContext context;
        public AccountRepo(AtmContext context)
        {
            this.context = context;
        }




        public Account? GetAccountById(int cardNumber, int pin)
        {
            Account? CheckedAccount = context.Accounts
                             .FirstOrDefault(i => i.CardNumber == cardNumber
                             && i.Pin == pin);
            return CheckedAccount;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }

}