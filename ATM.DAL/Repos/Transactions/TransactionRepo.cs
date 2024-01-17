

using ATM.DAL.DatabaseContext;
using ATM.DAL.Models.Transactions;

namespace ATM.DAL.Repos.Transactions
{

    public class TransactionRepo : ITransactionRepo
    {

        private readonly AtmContext context;
        public TransactionRepo(AtmContext context)
        {
            this.context = context;
        }

        public void AddWithSave(Transaction transaction)
        {
            context.Transactions.Add(transaction);
            context.SaveChanges();
        }


    }
}