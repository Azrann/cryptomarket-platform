using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CryptoMarketWeb.Services
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

    public class Crowdfund
    {
        public int ProjID { get; set; }
        public string ProjName { get; set; }
        public string ProjDesc { get; set; }
        public int ProjCatID { get; set; }
        public string ProjCatName { get; set; }
        public int ProjPackageID { get; set; }
        public string PackageName { get; set; }
        public int ProjTopOfUpcoming { get; set; }
        public string ProjImageURL { get; set; }
        public string ProjImageLargeURL { get; set; }
        public string ProjURL { get; set; }
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string EventStartDate { get; set; }
        public string EventEndDate { get; set; }
        public string EventURL { get; set; }
        public double Percent { get; set; }
        public string Status { get; set; }
        public int StatusID { get; set; }
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
