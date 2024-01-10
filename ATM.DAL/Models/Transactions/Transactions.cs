using System.ComponentModel.DataAnnotations.Schema;

namespace ATM.DAL;

    public class Transactions
    {
    public int Id { get; set; }
    public int Amount { get; set; }
    public DateTime Date { get; set; }
    public int accountsId { get; set; }

    [ForeignKey("accountsId")]
    public Accounts? accounts { get; set; }
}

