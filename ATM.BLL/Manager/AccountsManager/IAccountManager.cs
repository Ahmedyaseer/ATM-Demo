

namespace ATM.BLL;

    public interface IAccountManager
    {
        public AccountsDto Login(int cardNumber, int pin);
    }
