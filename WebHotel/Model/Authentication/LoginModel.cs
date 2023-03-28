﻿using System.ComponentModel.DataAnnotations;

namespace WebHotel.Model.Authentication
{
    public class LoginModel
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
