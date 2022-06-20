using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1.Models
{
    [Table("Payments_Post_Items")]
    public partial class PaymentsPostItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("id_user")]
        [StringLength(50)]
        public string IdUser { get; set; }
        [Column("id_package")]
        public int IdPackage { get; set; }
        [Column("_date", TypeName = "date")]
        public DateTime? Date { get; set; }

        [ForeignKey(nameof(IdPackage))]
        [InverseProperty(nameof(Package.PaymentsPostItems))]
        public virtual Package IdPackageNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.PaymentsPostItems))]
        public virtual User IdUserNavigation { get; set; }
    }
}
