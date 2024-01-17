

namespace ATM.BLL.DTOs.TransactionsDto
{



    public class TransactionDto
    {
        public string CardNumber { get; set; } = string.Empty;
        public string Pin { get; set; } =string.Empty;  
        public decimal Amount { get; set; }

    }
}

