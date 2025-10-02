using System;
using System.ComponentModel.DataAnnotations;

namespace BankAPI.Models
{
    public class Transactions
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public int AccountNumber { get; set; } // FK

        [Required]
        public string TransactionType { get; set; } // Deposit or Withdrawal

        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be positive")]
        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
        public int UserId { get; set; }  // link transaction to the user

    }
}
