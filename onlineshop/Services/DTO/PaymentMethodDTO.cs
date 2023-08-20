using onlineshop.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace onlineshop.Services.DTO
{
    public class PaymentMethodDTO
    {

        public string Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Name must be between 4 and 50")]
        public string Name { get; set; }

        public string UserDTOId { get; set; }

        public UserDTO userDTO { get; set; }

        [Required(ErrorMessage = "PaymetnType is required")]
        public PaymentType? PaymentType { get; set; }

        [Required(ErrorMessage = "Provider is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Provider must be between 6 and 50")]
        public string Provider { get; set; }

        [Required(ErrorMessage = "Number is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Number must be between 3 and 50")]
        public string Number { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ExpirationDate { get; set; }

        //[Required]
        //[Range(1,999, ErrorMessage = "CVV code must be between 1 and 999")]
        public int? CVV { get; set; }

        

    }
}
