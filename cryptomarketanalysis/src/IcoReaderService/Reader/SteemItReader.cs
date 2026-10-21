using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CryptoMarketAnalysis.DataAccess.DataAccess.Dtos;

namespace IcoReaderService.Reader
{
    public static class SteemitReader
    {
        public static async Task<SteemitImpact> GetImpact(string url)
        {
            url = UrlHelper.Sanitize(url);
            var name = url.Replace("https://steemit.com/", "");
            SteemitImpact result = new SteemitImpact();
            if (url.Contains("steemit"))
            {
                try
                {
                    /*TODO steammit not working*/
                    return result;
                    var mediumContent = (await HttpClientHelper.GetAsync(Uri.EscapeUriString(url), string.Empty));
                    var mediumString = await mediumContent.Content.ReadAsStringAsync();

                    Regex regex = new Regex(@"(?<=" + name + @""">).{1,12}?(?=</span> posts)");
                    Match match = regex.Match(mediumString);
                    if (match.Success)
                    {
                        result.Posts = int.Parse(match.Value.Replace(",", ""));
                    }

                    regex = new Regex(@"(?<=followers"">).{1,12}?(?=</span> followers)");
                    match = regex.Match(mediumString);
                    if (match.Success)
                    {
                        result.Followers = int.Parse(match.Value.Replace(",", ""));
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
