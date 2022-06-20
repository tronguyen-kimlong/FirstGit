using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1.Models
{
    [Table("Report_Account")]
    public partial class ReportAccount
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
        [Column("reason")]
        [StringLength(200)]
        public string Reason { get; set; }

        [ForeignKey(nameof(IdItems))]
        [InverseProperty(nameof(Item.ReportAccounts))]
        public virtual Item IdItemsNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.ReportAccounts))]
        public virtual User IdUserNavigation { get; set; }
    }
}
