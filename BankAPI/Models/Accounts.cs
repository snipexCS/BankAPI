using System.ComponentModel.DataAnnotations;

namespace BankAPI.Models
{
    public class Account
    {
        [Key]
        public int AccountNumber { get; set; }

        [Required]
        public int UserId { get; set; } // FK

        [Required]
        public string AccountType { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Balance cannot be negative")]
        public decimal Balance { get; set; }
    }
}
