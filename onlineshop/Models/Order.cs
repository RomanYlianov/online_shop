using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlineshop.Models
{
    [Table("order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("cipher")]
        public string Cipher { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }

        [Column("count")]
        public int Count { get; set; }

        [Column("final_price")]
        public double Price { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }

        [Column("deliverymethod_id")]
        public Guid DeliveryMethodId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        [Column("paymentmethod_id")]
        public Guid PaymentMethodId { get; set; }

        public User Buyer { get; set; }

        [Column("buyer_id")]
        public Guid BuyerId { get; set; }

        [Column("order_status")]
        public OrderStatus OrderStatus { get; set; }

        [Column("mark")]
        public double Mark { get; set; }

        [Column("receipt_code")]
        public Int16 ReceiptCode { get; set; }

        [Column("track_number")]
        public string TrackNumber { get; set; }

        [DataType(DataType.Date)]
        [Column("creation_time")]
        public DateTime CreationTime { get; set; }

        public virtual List<EvaluationQueue> EvaluationQueues { get; set; }
    }
}