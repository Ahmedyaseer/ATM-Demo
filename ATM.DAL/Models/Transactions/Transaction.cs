using System.ComponentModel.DataAnnotations.Schema;

namespace ATM.DAL;

    public class Transaction
    {
    public int Id { get; set; }
    public int Amount { get; set; }
    public DateTime Date { get; set; }
    public int accountId { get; set; }

    [ForeignKey("accountId")]
    public Account? accounts { get; set; }
}

