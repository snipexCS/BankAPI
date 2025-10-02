using System;

namespace BankAppMVC.Models
{
    public class TransactionModel
    {
        public int TransactionId { get; set; }
        public int AccountNumber { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
    }
}
