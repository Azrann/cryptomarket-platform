using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CryptoMarketAnalysis.DataAccess.DataAccess.Dtos;

namespace IcoReaderService.Reader
{
    public class TelegramReader
    {
        public static async Task<TelegramImpact> GetImpact(string url)
        {
            url = UrlHelper.Sanitize(url);
            TelegramImpact result = new TelegramImpact();
            try
            {
                var telegramString = await (await HttpClientHelper.GetAsync(url, string.Empty)).Content.ReadAsStringAsync();
                /*<div class="tgme_page_extra">265 members</div>*/
                Regex regex = new Regex(@"(?<=page_extra"">).{1,12}?(?= members)");
                Match match = regex.Match(telegramString);
                if (match.Success)
                {
                    result.Members = int.Parse(match.Value.Replace(",", ""));
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
