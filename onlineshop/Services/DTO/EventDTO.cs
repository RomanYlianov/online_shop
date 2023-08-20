using System;
using System.ComponentModel.DataAnnotations;

namespace onlineshop.Services.DTO
{
    public class EventDTO 
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "name is required")]
        [StringLength(50 , MinimumLength = 4, ErrorMessage = "Name is required")]
        public string Title { get; set; }

        //[Required(ErrorMessage = "ProductDTO is required")]
        public ProductDTO ProductDTO { get; set; }

        [Display(Name = "product")]
        [Required (ErrorMessage = "ProductId is required")]
        //[Range(1, int.MaxValue, ErrorMessage = "ProductDTOId must be positive")]
        public string ProductDTOId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Text must be between 10 and 500")]
        public string Text { get; set; }

        [DataType(DataType.DateTime), Required(ErrorMessage = "CreationTime is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? CreationTime { get; set; }

        

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? ExpirationTime { get; set; }

    }
}
