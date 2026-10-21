using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CryptoMarketAnalysis.DataAccess.DataAccess.Dtos;

namespace IcoReaderService.Reader
{
    public class MediumReader
    {
        public static async Task<MediumImpact> GetImpact(string url)
        {
            url = UrlHelper.Sanitize(url);
            MediumImpact result = new MediumImpact();
            if (url.Contains("medium"))
            {
                try
                {
                    var mediumContent = (await HttpClientHelper.GetAsync(Uri.EscapeUriString(url), string.Empty));
                    var mediumString = await mediumContent.Content.ReadAsStringAsync();

                    result.Followers = ExtractFollowers1(mediumString);
                    if (result.Followers == 0)
                    {
                        result.Followers = ExtractFollowers2(mediumString);
                    }
                }
                catch (Exception ex)
                {
                }
            }
           
            return result;
        }

        private static int ExtractFollowers1(string mediumString)
        {
            Regex regex = new Regex(@"(?<=title=""Show ).{1,12}?(?= followers)");
            Match match = regex.Match(mediumString);
            if (match.Success)
            {
                return GetNumber(match.Value);
            }

            return 0;
        }
        private static int ExtractFollowers2(string mediumString)
        {
            Regex regex = new Regex(@"(?<=<b>).{1,12}?(?=</b> Followers)");
            Match match = regex.Match(mediumString);
            if (match.Success)
            {
                return GetNumber(match.Value);
            }

            return 0;
        }

        private static int GetNumber(string matchValue)
        {
            if (matchValue.Contains("K"))
            {
                var number = decimal.Parse(matchValue.Replace("K", ""));
                return (int) Math.Round(number * 1000,0);
            }
            else
            {
                return int.Parse(matchValue.Replace(",", ""));
            }
        }
    }
}
