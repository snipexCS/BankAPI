using System.ComponentModel.DataAnnotations;

namespace BankAPI.Models
{
    public class Account
    {
        [Key]
        public int AccountNumber { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string AccountType { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Balance { get; set; }
    }
}
