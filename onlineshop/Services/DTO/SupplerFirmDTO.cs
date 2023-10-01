using System;
using System.ComponentModel.DataAnnotations;

namespace onlineshop.Services.DTO
{
    public class SupplerFirmDTO
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Address must be between 10 and 100")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [DataType(DataType.Date), Required(ErrorMessage = "RegisterDate is requires")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RegisterDate { get; set; }

        //[Required(ErrorMessage = "Rating is required")]
        //[Range(0, 10, ErrorMessage = "Rating must be 0 and 10")]
        public double Rating { get; set; }

        [Required(ErrorMessage = "MoneyValue is mandatory")]
        public double MoneyValue { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Description must be between 5 and 255")]
        public string Description { get; set; }
    }
}