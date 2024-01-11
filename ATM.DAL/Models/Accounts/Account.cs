

using ATM.DAL.Models.Transactions;

namespace ATM.DAL.Models.Accounts
{


    public class Account
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public int Pin { get; set; }
        public int Balance { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
    }
}