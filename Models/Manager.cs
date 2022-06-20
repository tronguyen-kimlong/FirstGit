using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1.Models
{
    [Table("Manager")]
    public partial class Manager
    {
        public Manager()
        {
            ApprovalItems = new HashSet<ApprovalItem>();
            BlockAccounts = new HashSet<BlockAccount>();
        }

        [Key]
        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [Column("password")]
        public string Password { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("phone", TypeName = "numeric(18, 0)")]
        public decimal? Phone { get; set; }
        [Column("roles")]
        [StringLength(10)]
        public string Roles { get; set; }

        [InverseProperty(nameof(ApprovalItem.IdManagerNavigation))]
        public virtual ICollection<ApprovalItem> ApprovalItems { get; set; }
        [InverseProperty(nameof(BlockAccount.IdManagerNavigation))]
        public virtual ICollection<BlockAccount> BlockAccounts { get; set; }
    }
}
