

using ATM.DAL.Models.Transactions;
using System.ComponentModel.DataAnnotations;

namespace ATM.DAL.Models.Accounts
{

    public class Account
    {
        public int Id { get; set; }
        public string CardNumber { get; set; } = String.Empty;

        [Range(0.0,double.MaxValue)]
        public decimal Balance { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
    }
}