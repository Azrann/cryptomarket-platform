using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CryptoMarketAnalysis.DataAccess.DataAccess.Dtos;

namespace IcoReaderService.Reader
{
    public class InstagramReader
    {
        public static async Task<InstagramImpact> GetImpact(string url)
        {
            url = UrlHelper.Sanitize(url);
            InstagramImpact result = new InstagramImpact();
            if (url.Contains("instagram"))
            {
                try
                {
                    var instagramContent = (await HttpClientHelper.GetAsync(Uri.EscapeUriString(url), string.Empty));
                    var instagramString = await instagramContent.Content.ReadAsStringAsync();

                    Regex regex = new Regex(@"(?<=content="").{1,12}?(?= Followers)");
                    Match match = regex.Match(instagramString);
                    if (match.Success)
                    {
                        result.Followers = int.Parse(match.Value.Replace(",", ""));
                    }

                    regex = new Regex(@"(?<=Following, ).{1,12}?(?= Posts)");
                    match = regex.Match(instagramString);
                    if (match.Success)
                    {
                        result.Posts = int.Parse(match.Value.Replace(",", ""));
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
