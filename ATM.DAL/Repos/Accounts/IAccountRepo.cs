
using ATM.DAL.Models.Accounts;

namespace ATM.DAL.Repos.Accounts
{

    public interface IAccountRepo
    {
        public Account? GetAccountById(string cardNumber );
        public void AddWithSaveChanges(Account account);
        public void Save();
    }
}