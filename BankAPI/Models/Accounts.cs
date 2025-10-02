
using System.ComponentModel.DataAnnotations;
namespace BankAPI.Models{
    public class Account
    {
        [Key]
        public int AccountNumber { get; set; }

        public int UserId { get; set; } // FK
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
    }
}
