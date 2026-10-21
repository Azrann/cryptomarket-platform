using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CryptoMarketAnalysis.DataAccess.DataAccess.Dtos;

namespace IcoReaderService.Reader
{
    public class RedditReader
    {
        public static async Task<RedditImpact> GetImpact(string url)
        {
            url = UrlHelper.Sanitize(url);
            RedditImpact result = new RedditImpact();
            if (url.Contains("user"))
            {
                try
                {
                    var redditString = await (await HttpClientHelper.GetAsync(url, string.Empty)).Content.ReadAsStringAsync();

                    Regex regex = new Regex(@"(?<=span>).{1,12}?(?= Karma)");
                    Match match = regex.Match(redditString);
                    if (match.Success)
                    {
                        result.Karma = int.Parse(match.Value.Replace(",", ""));
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return result;
        }
    }
}
