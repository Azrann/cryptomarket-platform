using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CryptoMarketAnalysis.DataAccess.DataAccess.Dtos;

namespace IcoReaderService.Reader
{
    public class LinkedInReader
    {
        public static async Task<LinkedInImpact> GetImpact(string url)
        {
            url = UrlHelper.Sanitize(url);
            LinkedInImpact result = new LinkedInImpact();
            if (url.Contains("company"))
            {
                try
                {
                    var linkedInString = await (await HttpClientHelper.GetAsync(url, string.Empty)).Content.ReadAsStringAsync();

                    /*TODO return a script page */
                    return result;
                    Regex regex = new Regex(@"(?<=top-card__information-text"">).{1,12}?(?= followers)");
                    Match match = regex.Match(linkedInString);
                    if (match.Success)
                    {
                        result.Followers = int.Parse(match.Value.Replace(",", ""));
                    }

                    regex = new Regex(@"(?<=see-all-employees""> See all).{1,12}?(?= employe)");
                    match = regex.Match(linkedInString);
                    if (match.Success)
                    {
                        result.Employees = int.Parse(match.Value.Replace(",", ""));
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
