using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoMarketAnalysis.DataAccess.DataAccess.Dtos;
using Newtonsoft.Json;

namespace IcoReaderService
{
    public class CoinApi
    {
        private string BaseUrl = "https://api.coinschedule.com/v2/";
        private string GetAllLiveCoinsUrl = "crowdfunds/live";
        private string GetAllUpcommingCoinsUrl = "crowdfunds/upcoming";
        private string Token = "E5D976A4A078C403";

        public async Task<List<Crowdfund>> GetAllLiveCoins()
        {
            var resultContent = await HttpClientHelper.GetAsync(BaseUrl, GetAllLiveCoinsUrl, Token);
            var resultString = await resultContent.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetAllCoinsResponse>(resultString);
            return result.crowdfunds;
        }

        public async Task<List<Crowdfund>> GetAllUpCommingCoins()
        {
            var resultContent = await HttpClientHelper.GetAsync(BaseUrl, GetAllUpcommingCoinsUrl, Token);
            var resultString = await resultContent.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetAllCoinsResponse>(resultString);
            return result.crowdfunds;
        }
    }

    public class GetAllCoinsResponse
    {
        public string message { get; set; }
        public string categories { get; set; }
        public string platforms { get; set; }
        public string package { get; set; }
        public List<Crowdfund> crowdfunds { get; set; }
    }
}
