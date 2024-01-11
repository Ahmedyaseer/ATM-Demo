

namespace ATM.BLL;

    public interface ITransactionManager
    {
    public TransactionDto? Withdraw(TransactionDto transactionDto);

    public TransactionDto? Deposit(TransactionDto transactionDto);



    }
