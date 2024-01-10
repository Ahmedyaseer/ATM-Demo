

using ATM.DAL;

namespace ATM.BLL;

    public  class AccountsManager : IAccountManager
    {
    private readonly IAccountsRepo accountRepo;

    public AccountsManager(IAccountsRepo accountRepo)
    {
        this.accountRepo = accountRepo;
    }
        public AccountsDto Login(int cardNumber , int pin)
    {
        Accounts? account = accountRepo.GetAccountById(cardNumber, pin);
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

