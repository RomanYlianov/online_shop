using System;
using System.ComponentModel.DataAnnotations;

namespace onlineshop.Services.DTO
{
    public class BasketDTO
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "ProductDTO is required")]
        public ProductDTO ProductDTO { get; set; }

        [Required(ErrorMessage = "ProductDTOId is required")]
        [Display(Name = "Product")]
        public string ProductDTOId { get; set; }

        [Required(ErrorMessage = "BuyerDTO is required")]
        public UserDTO BuyerDTO { get; set; }

        [Required(ErrorMessage = "BuyerDTOId is required")]
        [Display(Name = "Buyer")]
        public string BuyerDTOId { get; set; }

        [Required(ErrorMessage = "Count is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Count must be positive")]
        public int Count { get; set; }

        [Required(ErrorMessage = "IntermediateCost is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "IntermediateCost must be more than 0.01")]
        public double IntermediateCost { get; set; }
    }
}