

using ATM.BLL.DTOs.TransactionsDto;

namespace ATM.BLL.Manager.TransactionsManager
{

    public interface ITransactionManager
    {
        public TransactionDto? Withdraw(TransactionDto transactionDto);

        public TransactionDto? Deposit(TransactionDto transactionDto);



    }
}