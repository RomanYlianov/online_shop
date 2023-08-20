using onlineshop.Models;
using System;

namespace onlineshop.Services.DTO
{
    public class OrderSearchDTO
    {

        public string Cipher { get; set; }

        public string BuyerEmail { get; set; }

        public string DeliveryMethodId { get; set; }

        public PaymentType? PaymentType { get; set; }
        
        public OrderStatus? OrderStatus { get; set; }
        
        public DateTime? CreationTimeStart { get; set; }

        public DateTime? CreationTimeEnd { get; set; }

    }
}
