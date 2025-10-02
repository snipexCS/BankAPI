using System.ComponentModel.DataAnnotations;
namespace BankAPI.Models
{
    public class Transactions
    {
        [Key]
        public int TransactionId { get; set; }

        public int AccountNumber { get; set; } // FK
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
