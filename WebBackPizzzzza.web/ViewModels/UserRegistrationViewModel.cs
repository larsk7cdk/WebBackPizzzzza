﻿using System.ComponentModel.DataAnnotations;

namespace WebBackPizzzzza.web.ViewModels
{
    public class UserRegistrationViewModel
    {
        public int UserRegistrationId { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "EmailRequired")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "PasswordRequired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}