#region Using

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CryptoMarketWeb.DataAccess;
using CryptoMarketWeb.DataAccess.Dapper;
using CryptoMarketWeb.DataAccess.Entities;

#endregion

namespace SmartAdminMvc.Controllers
{
    public class TrendsController : Controller
    {
        TweetsDbService _service;
        CurrencyDbService _currencyDbService;
        public static List<string> KeyWords = new List<string> { "CRYPTO", "CRYPTOCURRENCIES", "CRYPTOS", "BLOCKCHAIN" };

        public TrendsController(TweetsDbService service, CurrencyDbService currencyDbService)
        {
            _service = service;
            _currencyDbService = currencyDbService;
        }
        // GET: home/lasthour
        public ActionResult LastHour()
        {
            ViewBag.Title = $"CryptoMarket in socialmedia in last hour";
            ViewBag.MetaDescription = $"A quick view of the Cryptocurrency market by looking at Twitter, Facebook and other Social media channels. Get the important information here to trade as the Experts.";

            var topOfHour = _service.GetTopOfHour();
            ViewBag.TopTweetOfHourWithInc = _service.GetTopOfHourWithIncrement().Where(x => !KeyWords.Contains(x.Key.ToUpper())).OrderBy(y => y.Total).ToList();
            ViewBag.OtherKeywords = topOfHour.Where(x => KeyWords.Contains(x.Key.ToUpper())).OrderByDescending(y => y.TweetCount).ToList();
            ViewBag.Currencies = GetCurrenciesDictionary();
            return View();
        }

        public ActionResult Last24Hours()
        {
            ViewBag.Title = $"CryptoMarket in socialmedia in last 24h";
            ViewBag.MetaDescription = $"A quick view of the Cryptocurrency market by looking at Twitter, Facebook and other Social media channels. Get the important information here to trade as the Experts.";

            var topOfHour = new List<TweetViewPerDayWithIncrement>();
            var topTweetWithInc =_service.GetTweetsViewLast24Hours();
            foreach (var keyWord in KeyWords)
            {
                topOfHour.Add(topTweetWithInc[keyWord]);
                topTweetWithInc.Remove(keyWord);
            }

            ViewBag.TopTweetWithInc = topTweetWithInc;
            ViewBag.OtherKeywords = topOfHour.Where(x => KeyWords.Contains(x.Key.ToUpper())).OrderByDescending(y => y.TweetCount).ToList();
            ViewBag.Currencies = GetCurrenciesDictionary();

            var tweetsLast24Hour = _service.GetTweetsLast24Hours();
            ViewBag.TweetsLast24Hour = tweetsLast24Hour.ToDictionary(x => x.Symbol, x => x.Numbers.Substring(0, x.Numbers.Length - 1)); //.Split(',').Where((c, i) => i % 12 == 0)
            return View();
        }

        public ActionResult Last7days()
        {
            ViewBag.Title = $"CryptoMarket in socialmedia in last 7 days";
            ViewBag.MetaDescription = $"A quick view of the Cryptocurrency market by looking at Twitter, Facebook and other Social media channels. Get the important information here to trade as the Experts.";
            return View();
        }

        private Dictionary<string, CurrencyInfo> GetCurrenciesDictionary()
        {
            var result = new Dictionary<string, CurrencyInfo>();
            foreach (var ci in _currencyDbService.GetCurrencies().OrderBy(x => x.rank))
            {
                if (!result.ContainsKey(ci.symbol))
                {
                    result.Add(ci.symbol.ToUpper(), ci);
                }
            }
            return result;
        }
    }
}