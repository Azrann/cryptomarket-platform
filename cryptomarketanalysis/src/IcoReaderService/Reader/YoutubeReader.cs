using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CryptoMarketAnalysis.DataAccess.DataAccess.Dtos;

namespace IcoReaderService.Reader
{
    public class YoutubeReader
    {
        public static async Task<YoutubeImpact> GetImpact(string url)
        {
            url = UrlHelper.Sanitize(url);
            YoutubeImpact result = new YoutubeImpact();
            try
            {
                var youtubeString = await (await HttpClientHelper.GetAsync(url, string.Empty)).Content.ReadAsStringAsync();

                Regex regex = new Regex(@"(?<=aria-label="").{1,12}?(?= subscribers)");
                Match match = regex.Match(youtubeString);
                if (match.Success)
                {
                    result.Subscribers = int.Parse(match.Value.Replace(",", ""));
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
