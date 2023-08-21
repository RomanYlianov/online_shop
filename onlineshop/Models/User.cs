using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlineshop.Models
{
    [Table("user")]
    public class User : IdentityUser<Guid>
    {
        public User() : base()
        {
        }

        [Column("fullname")]
        public string FullName { get; set; }

        [Column("KeyWord")]
        public string KeyWord { get; set; }

        [DataType(DataType.Date)]
        [Column("birthday")]
        public DateTime Birthday { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("is_vip")]
        public bool IsVIP { get; set; }

        [DataType(DataType.Date)]
        [Column("creation_time")]
        public DateTime CreationTime { get; set; }

        public User(bool isGeneratedPk = false)
        {
            if (isGeneratedPk)
            {
                this.Id = Guid.NewGuid();
            }
        }

        public virtual List<PaymentMethod> PaymentMethods { get; set; }

        public virtual List<Basket> Baskets { get; set; }

        public virtual List<Order> Orders { get; set; }

        public virtual List<EvaluationQueue> EvaluationQueues { get; set; }
    }
}