#region Using

using System.Collections.Generic;
using System.Web.Mvc;
using CryptoMarketWeb.DataAccess;
using CryptoMarketWeb.DataAccess.Dapper;

#endregion

namespace SmartAdminMvc.Controllers
{
    public class ReportsController : Controller
    {
        TweetsDbService _service;
        CurrencyDbService _currencyDbService;
        public static List<string> KeyWords = new List<string> { "CRYPTO", "CRYPTOCURRENCIES", "CRYPTOS", "BLOCKCHAIN" };

        public ReportsController(TweetsDbService service, CurrencyDbService currencyDbService)
        {
            _service = service;
            _currencyDbService = currencyDbService;
        }
        // GET: home/lasthour
        public ActionResult LastHour()
        {
            return View();
        }

        public ActionResult Last24Hours()
        {
            return View();
        }

        public ActionResult Last7days()
        {
            return View();
        }
    }
}