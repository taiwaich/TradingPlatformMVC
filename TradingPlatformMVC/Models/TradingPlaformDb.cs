namespace TradingPlatformMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TradingPlaformDb : DbContext
    {
        public TradingPlaformDb()
            : base("name=TradingPlaformDb")
        {
        }

        public virtual DbSet<broker> brokers { get; set; }
        public virtual DbSet<company> companies { get; set; }
        public virtual DbSet<currency> currencies { get; set; }
        public virtual DbSet<place> places { get; set; }
        public virtual DbSet<share> shares { get; set; }
        public virtual DbSet<shares_prices> shares_prices { get; set; }
        public virtual DbSet<stock_exchanges> stock_exchanges { get; set; }
        public virtual DbSet<trade> trades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<broker>()
                .HasMany(e => e.stock_exchanges)
                .WithMany(e => e.brokers)
                .Map(m => m.ToTable("broker_stock_ex").MapLeftKey("broker_id").MapRightKey("stock_ex_id"));

            modelBuilder.Entity<share>()
                .HasMany(e => e.shares_prices)
                .WithRequired(e => e.share)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<shares_prices>()
                .Property(e => e.price)
                .HasPrecision(10, 4);

            modelBuilder.Entity<trade>()
                .Property(e => e.price_total)
                .HasPrecision(20, 2);
        }
    }
}
