using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlineshop.Models
{
    [Table("evaluationQueue")]
    public class EvaluationQueue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public User Buyer { get; set; }

        [Column("buyer_id")]
        public Guid BuyerId { get; set; }

        public Product Product { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }

        public Order Order { get; set; }

        [Column("order_id")]
        public Guid OrderId { get; set; }

        [Column("is_added_comment")]
        public bool IsAddedComment { get; set; }

        [Column("is_rate_product")]
        public bool IsRateProduct { get; set; }
    }
}