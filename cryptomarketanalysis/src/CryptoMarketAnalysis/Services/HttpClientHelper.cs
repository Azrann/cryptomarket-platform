using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarketAnalysis.Services
{
    public class HttpClientHelper
    {
        private static HttpClient _client;

        public HttpClientHelper()
        {
            _client = new HttpClient();
        }

        public List<CurrencyResult> GetCurrencies()
        {
            var response = _client.GetAsync(" https://api.coinmarketcap.com/v1/ticker/").Result;
            var result = JsonConvert.DeserializeObject<List<CurrencyResult>>(response.Content.ReadAsStringAsync().Result.Replace("null","\"0\""));
            return result;
        }
    }
}
