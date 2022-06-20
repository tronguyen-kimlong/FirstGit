using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1.Models
{
    [Table("Package")]
    public partial class Package
    {
        public Package()
        {
            PaymentsPostItems = new HashSet<PaymentsPostItem>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("price", TypeName = "money")]
        public decimal? Price { get; set; }
        [Column("times_post")]
        public int? TimesPost { get; set; }
        [Column("category_num")]
        public int? CategoryNum { get; set; }

        [InverseProperty(nameof(PaymentsPostItem.IdPackageNavigation))]
        public virtual ICollection<PaymentsPostItem> PaymentsPostItems { get; set; }
    }
}
