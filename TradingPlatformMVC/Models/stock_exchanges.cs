namespace TradingPlatformMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class stock_exchanges
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public stock_exchanges()
        {
            trades = new HashSet<trade>();
            brokers = new HashSet<broker>();
        }

        [Key]
        public int stock_ex_id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(10)]
        public string symbol { get; set; }

        public int? place_id { get; set; }

        public virtual place place { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trade> trades { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<broker> brokers { get; set; }
    }
}
