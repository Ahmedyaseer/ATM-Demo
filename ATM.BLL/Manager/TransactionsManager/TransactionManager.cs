using ATM.DAL;

namespace ATM.BLL;

public class TransactionManager : ITransactionManager
{
    private readonly IAccountsRepo accountRepo;
    private readonly ITransactionsRepo transactionsRepo;

    public TransactionManager(IAccountsRepo accountRepo, ITransactionsRepo transactionsRepo)
    {
        this.accountRepo = accountRepo;
        this.transactionsRepo = transactionsRepo;
    }

    public TransactionDto? withdraw(TransactionDto transactionDto)
    {
        var account = accountRepo.GetAccountById(transactionDto.CardNumber, transactionDto.Pin);

        if (account == null) return null;

        if (account.Balance < transactionDto.Amount) return null;

        account.Balance -= transactionDto.Amount;
        accountRepo.SaveChanges();

        Transactions? t = new Transactions
        {
            Amount = -(transactionDto.Amount),
            Date = DateTime.Now,
            accountsId = account.Id
        };
        transactionsRepo.Add(t);
        transactionsRepo.Save();
        return transactionDto;
        
    }




    public TransactionDto? Deposit(TransactionDto transactionDto)
    {
        var account = accountRepo.GetAccountById(transactionDto.CardNumber, transactionDto.Pin);

        if (account == null) return null;


        account.Balance += transactionDto.Amount;
        accountRepo.SaveChanges();

        Transactions? t = new Transactions
        {
            Amount = transactionDto.Amount,
            Date = DateTime.Now,
            accountsId = account.Id
        };
        transactionsRepo.Add(t);
        transactionsRepo.Save();
        return transactionDto;

    }


}