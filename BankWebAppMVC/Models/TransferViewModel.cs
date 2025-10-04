using System.ComponentModel.DataAnnotations;

namespace BankWebAppMVC.Models
{
    public class TransferViewModel
    {
        [Required] public int FromAccount { get; set; }
        [Required] public int ToAccount { get; set; }
        [Required, Range(1, double.MaxValue)] public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
