using onlineshop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace onlineshop.Services.DTO
{
    public class OrderDTO
    {

        public string Id { get; set; }

        //[Required(ErrorMessage = "Cipher ie required")]
        public string Cipher { get; set; }
        
        //[Required(ErrorMessage = "Products is required")]
        public List<ProductDTO> ProductDTOs { get; set; }

        [Required(ErrorMessage = "Count is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Count must be positive")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be positive")]
        public double Price { get; set; }

        //[Required(ErrorMessage = "DeliveryMethodDTOId is required")]
        public DeliveryMethodDTO DeliveryMethodDTO { get; set; }

        [Display(Name = "Delivery method")]
        [Required(ErrorMessage = "DeliverymethodDTOId is required")]
        //[Range(1, int.MaxValue, ErrorMessage = "DeliverymethodDTOId must be positive")]
        public string DeliveryMethodDTOId { get; set; }

        //[Required(ErrorMessage = "PayMethoDTO is required")]
        public PaymentMethodDTO PaymentMethodDTO { get; set; }

        [Display(Name = "Payment method")]
        [Required(ErrorMessage = "PayMethodDTOId is required")]
        //[Range(1, int.MaxValue, ErrorMessage = "PayMethodDTOId is required")]
        public string PaymentMethodDTOId { get; set; }

      
        //[Required(ErrorMessage = "Butyer is required")]
        public UserDTO BuyerDTO { get; set; }

        [Display(Name = "Buyer")]
        [Required(ErrorMessage = "BuyerId is required")]
        public string BuyerDTOId { get; set; }

        //[Required(ErrorMessage = "OrderStatus is requiered")]
        public OrderStatus? OrderStatus { get; set; }

        //[Required(ErrorMessage = "Mark is required")]
        //[Range(0, 10, ErrorMessage = "Mark must be between 0 and 10")]
        public double Mark { get; set; }

        //[Required(ErrorMessage = "ReceiptCode is required")]
        //[Range(1000, 9999, ErrorMessage = "ReceiptCode must be between 1000 and 9999")]
        public Int16 ReceiptCode { get; set; }

        //[Required(ErrorMessage = "TrackNumber is required")]
        //[StringLength(50, MinimumLength = 10, ErrorMessage = "TrackNumber must be between 10 and 50")]
        public string TrackNumber { get; set; }

       // [Required(ErrorMessage = "CreationTime is required")]
        public DateTime CreationTime { get; set; }
    }
}
