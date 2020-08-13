namespace TradingPlatformMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class trade
    {
        [Key]
        public int trade_id { get; set; }

        public int? share_id { get; set; }

        public int? broker_id { get; set; }

        public int? stock_ex_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? transaction_time { get; set; }

        public int? share_amount { get; set; }

        public decimal? price_total { get; set; }

        public virtual broker broker { get; set; }

        public virtual share share { get; set; }

        public virtual stock_exchanges stock_exchanges { get; set; }
    }
}
