using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1.Models
{
    [Table("Block_Account")]
    public partial class BlockAccount
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("id_manager")]
        [StringLength(50)]
        public string IdManager { get; set; }
        [Required]
        [Column("id_user")]
        [StringLength(50)]
        public string IdUser { get; set; }
        [Column("reason")]
        public string Reason { get; set; }
        [Column("_date", TypeName = "date")]
        public DateTime? Date { get; set; }

        [ForeignKey(nameof(IdManager))]
        [InverseProperty(nameof(Manager.BlockAccounts))]
        public virtual Manager IdManagerNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.BlockAccounts))]
        public virtual User IdUserNavigation { get; set; }
    }
}
