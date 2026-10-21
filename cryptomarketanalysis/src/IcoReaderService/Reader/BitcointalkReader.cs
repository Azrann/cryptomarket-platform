using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CryptoMarketAnalysis.DataAccess.DataAccess.Dtos;

namespace IcoReaderService.Reader
{
    public class BitcointalkReader
    {
        public static async Task<BitcointalkImpact> GetImpact(string url)
        {
            url = UrlHelper.Sanitize(url);
            BitcointalkImpact result = new BitcointalkImpact();
            try
            {
                var bitcointalkstring = await (await HttpClientHelper.GetAsync(url, string.Empty)).Content.ReadAsStringAsync();
                /*<div class="tgme_page_extra">265 members</div> Read 1674 times)*/
                Regex regex = new Regex(@"(?<=Read ).{1,12}?(?= times)");
                Match match = regex.Match(bitcointalkstring);
                if (match.Success)
                {
                    result.Views = int.Parse(match.Value.Replace(",", ""));
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        private static string GetTweetsCharacters(string twitterString)
        {
            var pos1 = twitterString.IndexOf("Tweets, current page.", StringComparison.Ordinal);
            return twitterString.Substring(pos1, 138);
        }
    }
}
