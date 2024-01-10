

namespace ATM.DAL;

    public class TransactionsRepo : ITransactionsRepo
    {

    private readonly AtmContext context;
    public TransactionsRepo(AtmContext context)
    {
        this.context = context;
    }

    public void Add(Transactions transaction)
    {
        context.transactions.Add(transaction);
    }

    public void Save()
    {
        context.SaveChanges();  
    }
    }
