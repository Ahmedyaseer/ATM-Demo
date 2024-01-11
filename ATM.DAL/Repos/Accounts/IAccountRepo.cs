
using ATM.DAL.Models.Accounts;

namespace ATM.DAL.Repos.Accounts
{

    public interface IAccountRepo
    {
        public Account? GetAccountById(int cardNumber, int pin);
        public void SaveChanges();
    }
}