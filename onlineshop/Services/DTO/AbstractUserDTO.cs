using System;
using System.ComponentModel.DataAnnotations;

namespace onlineshop.Services.DTO
{
    public class AbstractUserDTO
    {

        public string Id { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        [StringLength(256, MinimumLength = 4, ErrorMessage = "UserName must be between 4 and 256")]
        //[Remote(action: "CheckUserName", controller: "Users", ErrorMessage = "UserName is already used")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(256, MinimumLength = 6, ErrorMessage = "Email must be between 6 and 256 ")]
        [EmailAddress(ErrorMessage = "Email is not correct")]
        //[Remote(action: "CheckEmail", controller: "Users", ErrorMessage = "Email is already used")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "PhoneNumber must be between 6 and 20")]
        [Phone(ErrorMessage = "PhonNumber is not correct")]
        //[Remote(action: "CheckPhoneNumber", controller: "Users", ErrorMessage = "PhoneNumber is already used")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "KeyWord is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "KeyWord must be between 4 and 50")]
        public string KeyWord { get; set; }

        [Required(ErrorMessage = "FullName is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "FullName must be between 6 and 100")]
        public string FullName { get; set; }

        [DataType(DataType.Date), Required(ErrorMessage = "Birthday is requires")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Address must be between 10 and 100")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Country is required")]
        //[StringLength(100, MinimumLength = 6, ErrorMessage = "Country must be between 6 and 100")]
        public string Country { get; set; }

      
        public bool IsVIP { get; set; } = false;
    }
}
