
namespace ATM.DAL;

public class Accounts
{
    public int Id { get; set; }
    public int CardNumber { get; set; }
    public int Pin { get; set; }
    public int Balance { get; set; }

    public ICollection<Transactions> Transactions { get; set; } = new HashSet<Transactions>(); 
}
