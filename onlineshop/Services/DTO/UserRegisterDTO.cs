using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace onlineshop.Services.DTO
{
    public class UserRegisterDTO : AbstractUserDTO
    {   

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required")]
        [Compare("Password", ErrorMessage = "passwords doesn't match")]
        public string PasswordConfirm { get; set; }

        public List<string> UserRoles { get; set; }

    }
}
