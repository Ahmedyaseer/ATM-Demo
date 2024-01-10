
namespace ATM.DAL;

    public interface IAccountsRepo
    {
    public Accounts? GetAccountById(int cardNumber, int pin);
    public void SaveChanges();
    }
