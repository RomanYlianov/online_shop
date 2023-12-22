using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlineshop.Models
{
    [Table("supplerfirm")]
    public class SupplerFirm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [DataType(DataType.Date)]
        [Column("register_date")]
        public DateTime RegisterDate { get; set; }

        [Column("rating")]
        public double Rating { get; set; }
        
        [Column("marks_count")]

        public long MarksCount { get; set; }

        [Column("money_value")]
        public double MoneyValue { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public virtual List<Product> Products { get; set; }

        public List<UserSupplerFirm> UserSupplerFirms { get; set; }
    }
}