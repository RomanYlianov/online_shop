using System.ComponentModel.DataAnnotations;

namespace onlineshop.Services.DTO
{
    public class EvaluationQueueDTO
    {

        public string Id { get; set; }

        [Required(ErrorMessage = "UserDTO is required")]
        public UserDTO BuyerDTO { get; set; }

        [Required(ErrorMessage = "UserDTOId is required")]
        public string BuyerDTOId { get; set; }

        [Required(ErrorMessage = "ProductDTO is required")]
        public ProductDTO ProductDTO { get; set; }

        [Required(ErrorMessage = "ProductDTOId is required")]
        public string ProductDTOId { get; set;}

        [Required(ErrorMessage = "OrderDTO is required")]
        public OrderDTO OrderDTO { get; set; }

        [Required(ErrorMessage = "OrderDTOId is required")]
        public string OrderDTOId { get; set; }

        [Required(ErrorMessage = "IsAddedComment is required")]
        public bool IsAddedComment { get; set; }

        [Required(ErrorMessage = "IsRateProduct ius required")]
        public bool IsRateProduct { get; set; }

    }
}
