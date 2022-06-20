using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1.Models
{
    [Table("Approval_Items")]
    public partial class ApprovalItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("id_manager")]
        [StringLength(50)]
        public string IdManager { get; set; }
        [Column("id_items")]
        public int IdItems { get; set; }
        [Column("_date", TypeName = "date")]
        public DateTime? Date { get; set; }
        [Column("reason")]
        public string Reason { get; set; }

        [ForeignKey(nameof(IdItems))]
        [InverseProperty(nameof(Item.ApprovalItems))]
        public virtual Item IdItemsNavigation { get; set; }
        [ForeignKey(nameof(IdManager))]
        [InverseProperty(nameof(Manager.ApprovalItems))]
        public virtual Manager IdManagerNavigation { get; set; }
    }
}
