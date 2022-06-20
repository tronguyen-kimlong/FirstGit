using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1.Models
{
    [Table("Favourite_Items")]
    public partial class FavouriteItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("id_user")]
        [StringLength(50)]
        public string IdUser { get; set; }
        [Column("id_items")]
        public int IdItems { get; set; }
        [Column("_date", TypeName = "date")]
        public DateTime? Date { get; set; }

        [ForeignKey(nameof(IdItems))]
        [InverseProperty(nameof(Item.FavouriteItems))]
        public virtual Item IdItemsNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.FavouriteItems))]
        public virtual User IdUserNavigation { get; set; }
    }
}
