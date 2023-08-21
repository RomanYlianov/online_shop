using System.ComponentModel.DataAnnotations;

namespace onlineshop.Services.DTO
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "LoginType is required")]
        public LoginType Type { get; set; }

        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password id required")]
        public string Password { get; set; }
    }
}