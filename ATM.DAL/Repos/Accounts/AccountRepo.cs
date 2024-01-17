

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



        public Account? GetAccountById(string cardNumber)
        {
            Account? CheckedAccount = context.Accounts
                             .FirstOrDefault(i => i.CardNumber == cardNumber);
            return CheckedAccount;
        }

        public void Save()
        {
            context.SaveChanges();  
        }

        public void AddWithSaveChanges(Account account)
        {
            context.Accounts.Add(account);
            context.SaveChanges();
        }
    }

}