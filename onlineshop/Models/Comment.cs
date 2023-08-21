using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlineshop.Models
{
    [Table("comment")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("tittle")]
        public string Title { get; set; }

        public User Author { get; set; }

        [Column("user_id")]
        public Guid? AuthorId { get; set; }

        public Product Product { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("creation_time")]
        public DateTime CreationTime { get; set; }

        [Column("modification_time")]
        public DateTime? ModificationTime { get; set; }
    }
}