using ATM.BLL.DTOs.TransactionsDto;
using ATM.DAL.Models.Transactions;
using ATM.DAL.Repos.Accounts;
using ATM.DAL.Repos.Transactions;

namespace ATM.BLL.Manager.TransactionsManager
{


    public class TransactionManager :  ITransactionManager 
    {
        private readonly IAccountRepo accountRepo;
        private readonly ITransactionRepo transactionsRepo;

        public TransactionManager(IAccountRepo accountRepo, ITransactionRepo transactionsRepo)
        {
            this.accountRepo = accountRepo;
            this.transactionsRepo = transactionsRepo;
        }

        public decimal Withdraw(string cardNumber, decimal amount)
        {

            var account = accountRepo.GetAccountById(cardNumber);

            if (account == null)
            {
                throw new ArgumentException("Account not found");
            }

            if (account.Balance < amount)
            {
                throw new ArgumentException("Insufficient funds");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Canot Withdraw Negtive Numbers");
            }

            account.Balance -= amount;
            accountRepo.Save();

            Transaction? newTransaction = new Transaction
            {
                Amount = -(amount),
                Date = DateTime.Now,
                accountId = account.Id
            };
            transactionsRepo.AddWithSave(newTransaction);

            return amount;

        }
            
     


        public decimal Deposit(string cardNumber, decimal amount)
        {
            var account = accountRepo.GetAccountById(cardNumber);

            if (account == null)
            {
                throw new ArgumentException("Account not found");
            }


            if (amount <= 0)
            {
                throw new ArgumentException("Canot Deposite Negtive Numbers");
            }

            account.Balance += amount;
            accountRepo.Save();

            Transaction? newTransaction = new Transaction
            {
                Amount = amount,
                Date = DateTime.Now,
                accountId = account.Id
            };
            transactionsRepo.AddWithSave(newTransaction);
            return amount;

        }


    }
}