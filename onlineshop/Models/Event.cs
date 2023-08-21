using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlineshop.Models
{
    [Table("event")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        public Product Product { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [DataType(DataType.Date)]
        [Column("creation_time")]
        public DateTime CreationTime { get; set; }

        [DataType(DataType.Date)]
        [Column("explanation_time")]
        public DateTime? ExpirationTime { get; set; }
    }
}