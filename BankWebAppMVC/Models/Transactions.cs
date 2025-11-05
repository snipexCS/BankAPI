using System;
using System.ComponentModel.DataAnnotations;

namespace BankWebAppMVC.Models
{
    public class Transactions
    {
        [Key]
        public int TransactionId { get; set; }
        [Required] public int AccountNumber { get; set; }
        [Required] public string TransactionType { get; set; }
        [Range(0.01, double.MaxValue)] public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
    }
}
