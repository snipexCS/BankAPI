using System.ComponentModel.DataAnnotations;

namespace BankWebAppMVC.Models
{
    public class UserProfile
    {
        public int UserId { get; set; }
        [Required] public string Name { get; set; }
        [Required, EmailAddress] public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [Required] public string Password { get; set; }
        public string Picture { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
