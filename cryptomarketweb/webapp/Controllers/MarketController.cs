#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CryptoMarketWeb.DataAccess;
using CryptoMarketWeb.DataAccess.Dapper;
using CryptoMarketWeb.DataAccess.Entities;
using Newtonsoft.Json;

#endregion

namespace SmartAdminMvc.Controllers
{
    public class MarketController : Controller
    {
        TweetsDbService _service;
        CurrencyDbService _currencyDbService;
        public static List<string> KeyWords = new List<string> { "CRYPTO", "CRYPTOCURRENCIES", "CRYPTOS", "BLOCKCHAIN" };

        public MarketController(TweetsDbService service, CurrencyDbService currencyDbService)
        {
            _service = service;
            _currencyDbService = currencyDbService;
        }
        public ActionResult Last24hours()
        {
            ViewBag.Title = $"CryptoMarket in last 24h";
            ViewBag.MetaDescription = $"A quick view of the Cryptocurrency market in the last Hour (Volume, MarketCap, Top Gainers). Get the important information here to trade as the Experts.";

            var topOfday = _service.GetTopOfDay();
            ViewBag.OtherKeywords = topOfday.Where(x => KeyWords.Contains(x.Key.ToUpper())).OrderByDescending(y => y.TweetCount).ToList();
            var currencyPrices = _currencyDbService.GetPricesLast24Hour();
            var marketCap = _currencyDbService.GetMarketCapLast24Hour();
            ViewBag.CurrencyPrices = currencyPrices.ToDictionary(x => x.Symbol, x => string.Join(",", x.Numbers.Substring(0, x.Numbers.Length - 1).Split(',').Where((c, i) => i % 12 == 0)));

            var marketCapString = GetMorrisData24h(marketCap);
            ViewBag.MarketCapData = marketCapString.ToString();
            ViewBag.MarketCapKeys = string.Join(",", marketCap.Select(x => $"'{x.Symbol}'").Distinct());
            var currencies = GetCurrenciesDictionary();
            ViewBag.Currencies = GetCurrenciesDictionary();

            var top5Volume = currencies.Values.OrderByDescending(x => (x.last24h_volume_usd*100)/ x.market_cap_usd).Take(5);
            ViewBag.Top5VolumeData = JsonConvert.SerializeObject(GetMorrisVolumeData(top5Volume)).Replace("\"name\"","name").Replace("\"value\"", "value");
            ViewBag.Top5VolumeKeys = string.Join(",", top5Volume.Select(x => $"'{x.symbol}'").Distinct());
            
            return View();
        }

        public ActionResult Lasthour()
        {
            ViewBag.Title = $"CryptoMarket in last hour";
            ViewBag.MetaDescription = $"A quick view of the Cryptocurrency market in the last Hour. Get the important information here to trade as the Experts.";

            var topOfHour = _service.GetTopOfHour();
            var currencyPrices = _currencyDbService.GetPricesLastHour();
            var marketCap = _currencyDbService.GetMarketCapLastHour();
            ViewBag.OtherKeywords = topOfHour.Where(x => KeyWords.Contains(x.Key.ToUpper())).OrderByDescending(y => y.TweetCount).ToList();
            ViewBag.CurrencyPrices = currencyPrices.ToDictionary(x => x.Symbol, x => x.Numbers.Substring(0, x.Numbers.Length - 1));

            var marketCapString = GetMorrisData(marketCap);
            ViewBag.MarketCapData = marketCapString.ToString();
            ViewBag.MarketCapKeys = string.Join(",", marketCap.Select(x => $"'{x.Symbol}'").Distinct()); 
            ViewBag.Currencies = GetCurrenciesDictionary();
            return View();
        }

        private static StringBuilder GetMorrisData(IEnumerable<MarketCapItem> marketCap)
        {
            var marketCapString = new StringBuilder();
            var counter = -1;
            foreach (var marketCapItem in marketCap)
            {
                counter++;
                if (counter > 4)
                {
                    counter = 0;
                    marketCapString.Append(",");
                }

                if (counter == 0)
                {
                    marketCapString.Append($"{{time: '{marketCapItem.Hour}:{marketCapItem.Minute}'");
                }

                marketCapString.Append($", {marketCapItem.Symbol}: {marketCapItem.MarketCap.Substring(0, marketCapItem.MarketCap.Length-9)}");
                if (counter == 4)
                {
                    marketCapString.Append("}");
                }
            }

            return marketCapString;
        }

        private static IEnumerable<object> GetMorrisVolumeData(IEnumerable<CurrencyInfo> currencyInfos)
        {
            /*TODO Divide MarketCap/24hourVolume that give % and we have to sort by that % and get top 5*/
            foreach (var currencyInfo in currencyInfos)
            {
                yield return new
                {
                    name = currencyInfo.symbol,
                    value = decimal.Round((currencyInfo.last24h_volume_usd * 100) / currencyInfo.market_cap_usd, 2, MidpointRounding.AwayFromZero)
                };
            }
        }
        

        private static StringBuilder GetMorrisData24h(IEnumerable<MarketCapItem> marketCap)
        {
            var marketCapString = new StringBuilder();
            var counter = -1;

            List<string> ignore = new List<string>();
            foreach (var marketCapItem in marketCap)
            {
                if (ignore.Contains(marketCapItem.Hour))
                {
                    continue;
                }

                counter++;
                if (counter > 4)
                {
                    counter = 0;
                    marketCapString.Append(",");
                }

                if (counter == 0)
                {
                    marketCapString.Append($"{{time: '{marketCapItem.Hour}'");
                }

                marketCapString.Append($", {marketCapItem.Symbol}: {marketCapItem.MarketCap.Substring(0, marketCapItem.MarketCap.Length - 9)}");
                if (counter == 4)
                {
                    ignore.Add(marketCapItem.Hour);
                    marketCapString.Append("}");
                }
            }

            return marketCapString;
        }
        public ActionResult Last7days()
        {
            return View();
        }
        
        public ActionResult Inbox()
        {
            return View();
        }

        public ActionResult Chat()
        {
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