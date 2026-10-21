using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarketAnalysis.Services
{
    public class CurrencyResult
    {
        [JsonProperty("id")]
        public string currencyid { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public Int16 rank { get; set; }
        public decimal price_usd { get; set; }
        public decimal price_btc { get; set; }
        [JsonProperty("24h_volume_usd")]
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
