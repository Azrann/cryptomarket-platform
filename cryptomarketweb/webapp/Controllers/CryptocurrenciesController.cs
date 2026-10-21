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
    public class CryptocurrenciesController : Controller
    {
        TweetsDbService _service;
        CurrencyDbService _currencyDbService;
        public static List<string> KeyWords = new List<string> { "CRYPTO", "CRYPTOCURRENCIES", "CRYPTOS", "BLOCKCHAIN" };

        public CryptocurrenciesController(TweetsDbService service, CurrencyDbService currencyDbService)
        {
            _service = service;
            _currencyDbService = currencyDbService;
        }
        public ActionResult Details(string cryptoName)
        {
            ViewBag.Title = $"{cryptoName} fundamental and technical analysis";
            ViewBag.MetaDescription = $"All you need to Know about {cryptoName}. Extensive fundamental and technical Analysis with social impact, trends and trading info.";
            if (string.IsNullOrEmpty(cryptoName))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Cryptocurrency = _currencyDbService.GetCrytpocurrency(cryptoName);
            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Title = $"List of all the cryptocurrencies with rating parameters";
            ViewBag.MetaDescription = $"A full list of cryptocurrencies, explore the next crypto that will do 1000%, do your homework and invest as the Whales by starting your research here.";

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