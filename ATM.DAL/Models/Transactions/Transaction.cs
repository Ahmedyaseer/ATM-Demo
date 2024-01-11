using System.ComponentModel.DataAnnotations.Schema;
using ATM.DAL.Models.Accounts;

namespace ATM.DAL.Models.Transactions
{

    public class Transaction
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int accountId { get; set; }

        [ForeignKey("accountId")]
        public Account? accounts { get; set; }
    }
}