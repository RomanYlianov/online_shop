using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace onlineshop.Models
{
    [Table("category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        [Column("name")]
        public string Name { get; set; }

        //public byte[] Photo { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public virtual List<Product> Products { get; set; } 

    }
}
