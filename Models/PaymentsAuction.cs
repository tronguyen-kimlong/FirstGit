using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1.Models
{
    [Table("Payments_Auction")]
    public partial class PaymentsAuction
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("id_user_buyer")]
        [StringLength(50)]
        public string IdUserBuyer { get; set; }
        [Required]
        [Column("id_user_seller")]
        [StringLength(50)]
        public string IdUserSeller { get; set; }
        [Required]
        [Column("account_bank_buyer")]
        [StringLength(50)]
        public string AccountBankBuyer { get; set; }
        [Required]
        [Column("account_bank_seller")]
        [StringLength(50)]
        public string AccountBankSeller { get; set; }
        [Column("cost", TypeName = "money")]
        public decimal Cost { get; set; }
        [Column("discount")]
        public int? Discount { get; set; }
        [Column("_date", TypeName = "date")]
        public DateTime? Date { get; set; }

        [ForeignKey(nameof(IdUserBuyer))]
        [InverseProperty(nameof(User.PaymentsAuctionIdUserBuyerNavigations))]
        public virtual User IdUserBuyerNavigation { get; set; }
        [ForeignKey(nameof(IdUserSeller))]
        [InverseProperty(nameof(User.PaymentsAuctionIdUserSellerNavigations))]
        public virtual User IdUserSellerNavigation { get; set; }
    }
}
