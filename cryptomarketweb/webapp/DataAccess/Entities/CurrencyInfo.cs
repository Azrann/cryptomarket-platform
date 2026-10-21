using System;

namespace CryptoMarketWeb.DataAccess.Entities
{
    public class CurrencyInfo 
    {

        public CurrencyInfo() 
        {
        }

        public Guid Id { get; set; }
        public string currencyId { get; set; }
        public string name { get; set; }
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
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

    public class CurrencyNumbers
    {
        public string Symbol { get; set; }
        public string Numbers { get; set; }
    }

    public class MarketCapItem
    {
        public string Symbol { get; set; }
        public string MarketCap { get; set; }
        public string Hour { get; set; }
        public string Minute { get; set; }
    }
}
