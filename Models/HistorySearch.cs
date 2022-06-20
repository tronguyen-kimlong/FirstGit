using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1.Models
{
    [Table("History_Search")]
    public partial class HistorySearch
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("id_user")]
        [StringLength(50)]
        public string IdUser { get; set; }
        [Column("keyword")]
        [StringLength(50)]
        public string Keyword { get; set; }

        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.HistorySearches))]
        public virtual User IdUserNavigation { get; set; }
    }
}
