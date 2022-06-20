using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1.Models
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("_name")]
        [StringLength(200)]
        public string Name { get; set; }

        [InverseProperty(nameof(Item.IdCategoryNavigation))]
        public virtual ICollection<Item> Items { get; set; }
    }
}
