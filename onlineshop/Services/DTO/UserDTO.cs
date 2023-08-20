using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace onlineshop.Services.DTO
{
    public class UserDTO: AbstractUserDTO
    {

        public string NormalizedUserName { get; set; }

        public string NormailzedEmail { get; set; }

        [Required(ErrorMessage = "EmailConfirmed is required")]
        public bool EmailConfirmed { get; set; }

        [Required(ErrorMessage = "PasswordHash is required")]
        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string ConcurrencyStamp { get; set; }

        [Required(ErrorMessage = "PhoneNumberConfirmed is required")]
        public bool PhoneNumberConfirmed { get; set; }

        [Required(ErrorMessage = "TwoFactorEnabled is required")]
        public bool TwoFactorEnabled { get; set; }

        public DateTimeOffset? LookOutEnd { get; set; }

        [Required(ErrorMessage = "LookOutEnabled is required")]
        public bool LookOutEnabled { get; set; }

        [Required(ErrorMessage = "AccessFailedCount is required")]
        public int AccessFailedCount { get; set; }

        //[Required(ErrorMessage = "CreationTime is required")]
        [DataType(DataType.DateTime), Required(ErrorMessage = "CreationTime is require")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreationTime { get; set; }

    }
}
