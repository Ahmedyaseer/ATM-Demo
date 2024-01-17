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

        public TransactionDto? Withdraw(TransactionDto transactionDto)
        {




            var account = accountRepo.GetAccountById(transactionDto.CardNumber);

            if (account == null)
            {
                throw new ArgumentException("Account not found");
            }

            if (account.Balance < transactionDto.Amount)
            {
                throw new ArgumentException("Insufficient funds");
            }

            if (transactionDto.Amount <= 0)
            {
                throw new ArgumentException("Canot Withdraw Negtive Numbers");
            }

            account.Balance -= transactionDto.Amount;
            accountRepo.Save();

            Transaction? NewTransaction = new Transaction
            {
                Amount = -(transactionDto.Amount),
                Date = DateTime.Now,
                accountId = account.Id
            };
            transactionsRepo.AddWithSave(NewTransaction);
            return transactionDto;

        }
            
     


        public TransactionDto? Deposit(TransactionDto transactionDto)
        {
            var account = accountRepo.GetAccountById(transactionDto.CardNumber );

            if (account == null)
            {
                throw new ArgumentException("Account not found");
            }


            if (transactionDto.Amount <= 0)
            {
                throw new ArgumentException("Canot Deposite Negtive Numbers");
            }

            account.Balance += transactionDto.Amount;
            accountRepo.Save();

            Transaction? NewTransaction = new Transaction
            {
                Amount = transactionDto.Amount,
                Date = DateTime.Now,
                accountId = account.Id
            };
            transactionsRepo.AddWithSave(NewTransaction);
            return transactionDto;

        }


    }
}