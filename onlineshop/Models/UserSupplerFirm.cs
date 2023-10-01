using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlineshop.Models
{
    [Table("UserSupplerFirm")]
    public class UserSupplerFirm
    {

        public User Seller { get; set; }

        [Column("user_id")]
        public Guid SellerId { get; set; }

        public SupplerFirm SupplerFirm {get; set;}

        [Column("supplerfirm_id")]
        public Guid SupplerFirmId { get; set; }

        public UserSupplerFirm() { }
       

        public UserSupplerFirm(Guid sellerId, Guid supplerFirmId)
        {
            this.SellerId = sellerId;
            this.SupplerFirmId = supplerFirmId;
        }

    }
}
