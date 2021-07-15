﻿using System.ComponentModel.DataAnnotations;

namespace pointOfSale.Api.Models
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
