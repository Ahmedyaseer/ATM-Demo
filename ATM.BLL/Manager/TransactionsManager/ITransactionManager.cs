

namespace ATM.BLL;

    public interface ITransactionManager
    {
    public TransactionDto? withdraw(TransactionDto transactionDto);

    public TransactionDto? Deposit(TransactionDto transactionDto);



    }
