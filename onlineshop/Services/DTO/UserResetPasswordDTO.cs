using System.ComponentModel.DataAnnotations;

namespace onlineshop.Services.DTO
{
    public class UserResetPasswordDTO
    {
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(256, MinimumLength = 4, ErrorMessage = "UserName must be between 4 and 256")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required")]
        [Compare("Password", ErrorMessage = "passwords doesn't match")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "KeyWord is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "KeyWord must be between 4 and 50")]
        public string KeyWord { get; set; }
    }
}