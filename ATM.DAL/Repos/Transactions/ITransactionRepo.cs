

using ATM.DAL.Models.Transactions;

namespace ATM.DAL.Repos.Transactions
{
    public interface ITransactionRepo
    {
        public void Add(Transaction transaction);

    }

}