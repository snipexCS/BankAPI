using System;

namespace BankAppMVC.Models
{
    // TransactionModel
    public class TransactionModel
    {
        public int TransactionId { get; set; }
        public int AccountNumber { get; set; }
        public DateTime Date { get; set; }       // make sure it's DateTime
        public string Type { get; set; }         // if your API has Type
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }

}
