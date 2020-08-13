namespace TradingPlatformMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class shares_prices
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int share_id { get; set; }

        public decimal? price { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime time_start { get; set; }

        [Column(TypeName = "date")]
        public DateTime? time_end { get; set; }

        public virtual share share { get; set; }
    }
}
