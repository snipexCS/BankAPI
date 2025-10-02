﻿
using System.ComponentModel.DataAnnotations;

namespace BankAPI.Models
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
    }
}
