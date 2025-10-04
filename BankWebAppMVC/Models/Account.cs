namespace BankWebAppMVC.Models
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public int UserId { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
    }
}
