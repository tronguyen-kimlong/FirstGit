using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Item
    {
        public Item()
        {
            ApprovalItems = new HashSet<ApprovalItem>();
            FavouriteItems = new HashSet<FavouriteItem>();
            HistoryBuys = new HashSet<HistoryBuy>();
            ReportAccounts = new HashSet<ReportAccount>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("id_category")]
        public int IdCategory { get; set; }
        [Required]
        [Column("id_user")]
        [StringLength(50)]
        public string IdUser { get; set; }
        [Column("image_items")]
        public byte[] ImageItems { get; set; }
        [Column("description")]
        [StringLength(200)]
        public string Description { get; set; }
        [Column("_date", TypeName = "date")]
        public DateTime? Date { get; set; }
        [Column("isaccept")]
        public bool? Isaccept { get; set; }
        [Column("price", TypeName = "money")]
        public decimal? Price { get; set; }
        [Column("price_buy_now", TypeName = "money")]
        public decimal? PriceBuyNow { get; set; }
        [Column("auction", TypeName = "date")]
        public DateTime? Auction { get; set; }
        [Column("price_auction", TypeName = "money")]
        public decimal? PriceAuction { get; set; }

        [ForeignKey(nameof(IdCategory))]
        [InverseProperty(nameof(Category.Items))]
        public virtual Category IdCategoryNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.Items))]
        public virtual User IdUserNavigation { get; set; }
        [InverseProperty(nameof(ApprovalItem.IdItemsNavigation))]
        public virtual ICollection<ApprovalItem> ApprovalItems { get; set; }
        [InverseProperty(nameof(FavouriteItem.IdItemsNavigation))]
        public virtual ICollection<FavouriteItem> FavouriteItems { get; set; }
        [InverseProperty(nameof(HistoryBuy.IdItemsNavigation))]
        public virtual ICollection<HistoryBuy> HistoryBuys { get; set; }
        [InverseProperty(nameof(ReportAccount.IdItemsNavigation))]
        public virtual ICollection<ReportAccount> ReportAccounts { get; set; }
    }
}
