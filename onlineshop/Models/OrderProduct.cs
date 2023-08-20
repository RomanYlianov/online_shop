using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace onlineshop.Models
{

    [Table("OrderProduct")]
    public class OrderProduct
    {
        public Order Order { get; set; }

        [Column("order_id")]
        public Guid OrderId { get; set; }

        public Product Product { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }

        [Column("products_count")]
        public int ProductsCount { get; set; }

    }
}
