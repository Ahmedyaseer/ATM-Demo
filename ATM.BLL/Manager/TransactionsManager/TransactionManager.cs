using ATM.DAL;

namespace ATM.BLL;

public class TransactionManager : ITransactionManager
{
    private readonly IAccountRepo accountRepo;
    private readonly ITransactionRepo transactionsRepo;

    public TransactionManager(IAccountRepo accountRepo, ITransactionRepo transactionsRepo)
    {
        this.accountRepo = accountRepo;
        this.transactionsRepo = transactionsRepo;
    }

    public TransactionDto? Withdraw(TransactionDto transactionDto)
    {
        var account = accountRepo.GetAccountById(transactionDto.CardNumber, transactionDto.Pin);

        if (account == null)
        {
            throw new ArgumentException("Account not found");
        }

        if (account.Balance < transactionDto.Amount)
        {
            throw new ArgumentException("Insufficient funds");
        }

        account.Balance -= transactionDto.Amount;
        accountRepo.SaveChanges();

        Transaction? NewTransaction = new Transaction
        {
            Amount = -(transactionDto.Amount),
            Date = DateTime.Now,
            accountId = account.Id
        };
        transactionsRepo.Add(NewTransaction);
        return transactionDto;
        
    }




    public TransactionDto? Deposit(TransactionDto transactionDto)
    {
        var account = accountRepo.GetAccountById(transactionDto.CardNumber, transactionDto.Pin);

        if (account == null) 
        {
            throw new ArgumentException("Account not found");
        }

        account.Balance += transactionDto.Amount;
        accountRepo.SaveChanges();

        Transaction? t = new Transaction
        {
            Amount = transactionDto.Amount,
            Date = DateTime.Now,
            accountId = account.Id
        };
        transactionsRepo.Add(t);
        return transactionDto;

    }


}