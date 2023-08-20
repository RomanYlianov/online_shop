using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlineshop.Models
{
    [Table("paymentmethod")]
    public class PaymentMethod
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        public User User { get; set; }

        [Column("payment_type")]
        public PaymentType PaymentType { get; set; }

        [Column("provider")]
        public string Provider { get; set; }

        [Column("number")]
        public string Number { get; set; }

        [Column("expiration_date")]
        public DateTime? ExpirationDate { get; set; }

        [Column("CVV")]
        public int? CVV { get; set; }

        public virtual List<Order> Orders { get; set; }


    }
}
