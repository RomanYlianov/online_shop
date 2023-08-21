using onlineshop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace onlineshop.Services.DTO
{
    public class OrderDTO
    {
        public string Id { get; set; }

        public string Cipher { get; set; }

        public List<ProductDTO> ProductDTOs { get; set; }

        [Required(ErrorMessage = "Count is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Count must be positive")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be positive")]
        public double Price { get; set; }

        public DeliveryMethodDTO DeliveryMethodDTO { get; set; }

        [Display(Name = "Delivery method")]
        [Required(ErrorMessage = "DeliverymethodDTOId is required")]
        public string DeliveryMethodDTOId { get; set; }

        public PaymentMethodDTO PaymentMethodDTO { get; set; }

        [Display(Name = "Payment method")]
        [Required(ErrorMessage = "PayMethodDTOId is required")]
        public string PaymentMethodDTOId { get; set; }

        public UserDTO BuyerDTO { get; set; }

        [Display(Name = "Buyer")]
        [Required(ErrorMessage = "BuyerId is required")]
        public string BuyerDTOId { get; set; }

        public OrderStatus? OrderStatus { get; set; }

        public double Mark { get; set; }

        public Int16 ReceiptCode { get; set; }

        public string TrackNumber { get; set; }

        public DateTime CreationTime { get; set; }
    }
}