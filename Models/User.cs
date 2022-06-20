using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1.Models
{
    public partial class User
    {
        public User()
        {
            BlockAccounts = new HashSet<BlockAccount>();
            FavouriteItems = new HashSet<FavouriteItem>();
            HistoryBuys = new HashSet<HistoryBuy>();
            HistorySearches = new HashSet<HistorySearch>();
            Items = new HashSet<Item>();
            PaymentsAuctionIdUserBuyerNavigations = new HashSet<PaymentsAuction>();
            PaymentsAuctionIdUserSellerNavigations = new HashSet<PaymentsAuction>();
            PaymentsPostItems = new HashSet<PaymentsPostItem>();
            PostItems = new HashSet<PostItem>();
            ReportAccounts = new HashSet<ReportAccount>();
        }

        [Key]
        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [Column("password")]
        public string Password { get; set; }
        [Column("gender")]
        [StringLength(10)]
        public string Gender { get; set; }
        [Column("phone", TypeName = "numeric(18, 0)")]
        public decimal? Phone { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("lockuser")]
        [StringLength(10)]
        public string Lockuser { get; set; }
        [Column("address")]
        [StringLength(50)]
        public string Address { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("paypal_sandbox")]
        [StringLength(50)]
        public string PaypalSandbox { get; set; }
        [Column("wallet", TypeName = "money")]
        public decimal Wallet { get; set; }

        [InverseProperty(nameof(BlockAccount.IdUserNavigation))]
        public virtual ICollection<BlockAccount> BlockAccounts { get; set; }
        [InverseProperty(nameof(FavouriteItem.IdUserNavigation))]
        public virtual ICollection<FavouriteItem> FavouriteItems { get; set; }
        [InverseProperty(nameof(HistoryBuy.IdUserNavigation))]
        public virtual ICollection<HistoryBuy> HistoryBuys { get; set; }
        [InverseProperty(nameof(HistorySearch.IdUserNavigation))]
        public virtual ICollection<HistorySearch> HistorySearches { get; set; }
        [InverseProperty(nameof(Item.IdUserNavigation))]
        public virtual ICollection<Item> Items { get; set; }
        [InverseProperty(nameof(PaymentsAuction.IdUserBuyerNavigation))]
        public virtual ICollection<PaymentsAuction> PaymentsAuctionIdUserBuyerNavigations { get; set; }
        [InverseProperty(nameof(PaymentsAuction.IdUserSellerNavigation))]
        public virtual ICollection<PaymentsAuction> PaymentsAuctionIdUserSellerNavigations { get; set; }
        [InverseProperty(nameof(PaymentsPostItem.IdUserNavigation))]
        public virtual ICollection<PaymentsPostItem> PaymentsPostItems { get; set; }
        [InverseProperty(nameof(PostItem.IdUserNavigation))]
        public virtual ICollection<PostItem> PostItems { get; set; }
        [InverseProperty(nameof(ReportAccount.IdUserNavigation))]
        public virtual ICollection<ReportAccount> ReportAccounts { get; set; }
    }
}
