using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlineshop.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("cipher")]
        public string Cipher { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public Category Category { get; set; }

        [Column("category_id")]
        public Guid CategoryId { get; set; }

        public SupplerFirm SupplerFirm { get; set; }

        [Column("supplerfirm_id")]
        public Guid SupplerFirmId { get; set; }


        [Column("count_all")]
        public int CountAll { get; set; }

        //[Column("count_this")]
       // public int CountThis { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("rating")]
        public double Rating { get; set; }


        [Column("is_hot")]
        public bool IsHot { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<Event> Events { get; set; }

        public virtual List<Basket> Baskets { get; set; }

        public virtual List<EvaluationQueue> EvaluationQueues { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
    }
}