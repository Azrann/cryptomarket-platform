using System.Threading.Tasks;
using CryptoMarketAnalysis.DataAccess.DataAccess.Dtos;
using CryptoMarketAnalysis.DataAccess.DataAccess.Entities;

namespace IcoReaderService.Reader
{
    public class SocialReader
    {
        public static async Task<SocialImpact> GetImpact(IcoLinks links)
        {
            var result = new SocialImpact();
            foreach (var link in links.GetLinks())
            {
                switch (link.Key)
                {
                    case Links.BitcoinTalk: result.Set(await BitcointalkReader.GetImpact(link.Value)); break;
                    case Links.Github: break;
                    case Links.Instagram: result.Set(await InstagramReader.GetImpact(link.Value)); break;
                    case Links.Telegram: result.Set(await TelegramReader.GetImpact(link.Value)); break;
                    case Links.Twitter: result.Set(await TwitterReader.GetImpact(link.Value)); break;
                    case Links.Youtube: result.Set(await YoutubeReader.GetImpact(link.Value)); break;
                    case Links.Blog: result.Set(await MediumReader.GetImpact(link.Value)); break;
                    case Links.Reddit: result.Set(await RedditReader.GetImpact(link.Value)); break;
                    case Links.Steemit: result.Set(await SteemitReader.GetImpact(link.Value)); break;
                    case Links.LinkedIn: result.Set(await LinkedInReader.GetImpact(link.Value)); break;
                    default: break;
                }
            }
            return result;
        }
    }
}
