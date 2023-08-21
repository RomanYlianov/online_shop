using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlineshop.Models
{
    [Table("role")]
    public class Role : IdentityRole<Guid>
    {
        [Column("description")]
        public string Description { get; set; }

        public Role() : base()
        {
        }

        public Role(string name, string description, bool isGeneratedPK = false) : base(name)
        {
            if (isGeneratedPK)
            {
                this.Id = Guid.NewGuid();
            }

            Description = description;
        }
    }
}