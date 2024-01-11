
namespace ATM.DAL;

    public interface IAccountRepo
    {
    public Account? GetAccountById(int cardNumber, int pin);
    public void SaveChanges();
    }
