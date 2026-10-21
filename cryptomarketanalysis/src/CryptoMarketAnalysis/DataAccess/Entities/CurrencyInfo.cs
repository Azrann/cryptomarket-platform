using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoMarketAnalysis.DataAccess.Entities
{
    public class CurrencyInfo : Entity<Guid>
    {

        public CurrencyInfo(Guid Id) : base(Id)
        {
        }

        public CurrencyInfo()
        {
            this.Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            LastUpdated = DateTime.UtcNow;
        }

        [StringLength(25)]
        public string currencyId { get; set; }
        [StringLength(25)]
        public string name { get; set; }
        [StringLength(6)]
        public string symbol { get; set; }
        public Int16 rank { get; set; }
        public decimal price_usd { get; set; }
        public decimal price_btc { get; set; }
        public decimal last24h_volume_usd { get; set; }
        public decimal market_cap_usd { get; set; }
        public decimal available_supply { get; set; }
        public decimal total_supply { get; set; }
        public decimal percent_change_1h { get; set; }
        public decimal percent_change_24h { get; set; }
        public decimal percent_change_7d { get; set; }
        public long last_updated { get; set; }
    }
}
