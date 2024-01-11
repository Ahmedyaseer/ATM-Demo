

using ATM.BLL.DTOs.AccountsDto;

namespace ATM.BLL.Manager.AccountsManager
{

    public interface IAccountManager
    {
        public AccountsDto Login(int cardNumber, int pin);
    }
}