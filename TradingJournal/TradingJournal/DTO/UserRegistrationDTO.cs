﻿using System.ComponentModel.DataAnnotations;

namespace TradingJournal.DTO
{
    public class UserRegistrationDTO
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }
    }
}
