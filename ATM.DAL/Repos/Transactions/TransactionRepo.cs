

namespace ATM.DAL;

    public class TransactionRepo : ITransactionRepo
    {

    private readonly AtmContext context;
    public TransactionRepo(AtmContext context)
    {
        this.context = context;
    }

    public void Add(Transaction transaction)
    {
        context.Transactions.Add(transaction);
        context.SaveChanges();
    }

    
    }
