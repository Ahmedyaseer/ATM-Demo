

using ATM.BLL.DTOs.TransactionsDto;

namespace ATM.BLL.Manager.TransactionsManager
{

    public interface ITransactionManager
    {
        public decimal Withdraw(string cardNumber, decimal amount);

        public decimal Deposit(string cardNumber, decimal amount);



    }
}