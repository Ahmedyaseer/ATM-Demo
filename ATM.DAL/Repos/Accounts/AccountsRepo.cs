

namespace ATM.DAL;

    public class AccountsRepo : IAccountsRepo   
{
    private readonly AtmContext context;
    public AccountsRepo(AtmContext context)
    {
        this.context = context;
    }




    public Accounts? GetAccountById(int cardNumber , int pin)
    {
       Accounts? account = context.accounts.FirstOrDefault(i=>i.CardNumber == cardNumber && i.Pin == pin );
        return account;
    }

    public void SaveChanges()
    {
        context.SaveChanges();  
    }
}

