

using ATM.DAL;

namespace ATM.BLL;

    public  class AccountManager : IAccountManager
    {
    private readonly IAccountRepo accountRepo;

    public AccountManager(IAccountRepo accountRepo)
    {
        this.accountRepo = accountRepo;
    }
        public AccountsDto Login(int cardNumber , int pin)
    {
        Account? account = accountRepo.GetAccountById(cardNumber, pin);
        if( account == null)
        {
            return null;
        }
        return new AccountsDto
        {
            Balance = account.Balance
        };
    }
    }

