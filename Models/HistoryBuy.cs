using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1.Models
{
    [Table("History_Buy")]
    public partial class HistoryBuy
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
        [InverseProperty(nameof(Item.HistoryBuys))]
        public virtual Item IdItemsNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.HistoryBuys))]
        public virtual User IdUserNavigation { get; set; }
    }
}
