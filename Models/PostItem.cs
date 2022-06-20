using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PostItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("id_user")]
        [StringLength(50)]
        public string IdUser { get; set; }
        [Column("category_num")]
        public int? CategoryNum { get; set; }
        [Column("times_post")]
        public int? TimesPost { get; set; }

        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.PostItems))]
        public virtual User IdUserNavigation { get; set; }
    }
}
