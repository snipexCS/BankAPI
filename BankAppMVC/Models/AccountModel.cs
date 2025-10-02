namespace BankAppMVC.Models
{
    public class AccountModel
    {
        public int AccountNumber { get; set; }
        public int UserId { get; set; }
        public string AccountType { get; set; } // e.g., "Savings"
        public decimal Balance { get; set; }
    }
}
