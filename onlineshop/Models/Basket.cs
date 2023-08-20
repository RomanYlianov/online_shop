using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlineshop.Models
{
    [Table("basket")]
    public class Basket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        //[ForeignKey("productId")]
        public Product Product { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }

        public User Buyer { get; set; }

        [Column("buyer_id")]
        public Guid BuyerId { get; set; }

        [Column("count")]
        public int Count { get; set; }

        [Column("intermediate_cost")]
        public double IntermediateCost { get; set; }


    }
}
