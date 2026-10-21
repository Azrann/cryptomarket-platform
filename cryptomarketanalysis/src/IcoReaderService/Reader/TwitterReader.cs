using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CryptoMarketAnalysis.DataAccess.DataAccess.Dtos;

namespace IcoReaderService.Reader
{
    public class TwitterReader
    {
        public static async Task<TwitterImpact> GetImpact(string url)
        {
            url = UrlHelper.Sanitize(url);
            TwitterImpact result = new TwitterImpact(); try
            {
                var twitterString = await (await HttpClientHelper.GetAsync(url, string.Empty)).Content.ReadAsStringAsync();
                Regex regex = new Regex(@"(?<=title="").{1,12}?(?= Followers"")");
                Match match = regex.Match(twitterString);
                if (match.Success)
                {
                    result.Followers = int.Parse(match.Value.Replace(",", ""));
                }

                var subTwitterString = GetTweetsCharacters(twitterString);
                regex = new Regex(@"(?<=count=).{1,12}?(?= data)");
                match = regex.Match(subTwitterString);
                if (match.Success)
                {
                    result.Tweets = int.Parse(match.Value.Replace(",", ""));
                }
                regex = new Regex(@"(?<=title="").{1,12}?(?= Likes"")");
                match = regex.Match(twitterString);
                if (match.Success)
                {
                    result.Likes = int.Parse(match.Value.Replace(",", ""));
                }

                regex = new Regex(@"(?<=title="").{1,12}?(?= Following"")");
                match = regex.Match(twitterString);
                if (match.Success)
                {
                    result.Following = int.Parse(match.Value.Replace(",", ""));
                }

                regex = new Regex(@"(?<=title="").{1,12}?(?= List)");
                match = regex.Match(twitterString);
                if (match.Success)
                {
                    result.Lists = int.Parse(match.Value.Replace(",", ""));
                }

                if (result.Followers == 0 && result.Tweets > 0)
                {
                    System.IO.File.WriteAllText(
                        @"logs\" + url.Replace("https://twitter.com/", "") + DateTime.UtcNow.Hour + ".txt",
                        twitterString);
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
