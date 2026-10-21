#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using CryptoMarketWeb.DataAccess;
using CryptoMarketWeb.DataAccess.Entities;
using CryptoMarketWeb.Services;
using SimpleFeedReader;

#endregion

namespace SmartAdminMvc.Controllers
{
    public class IcoController : Controller
    {
        private CoinTelegraphReader _reader;
        private readonly CoinApi _coinApi;
        private readonly IcoSocialDbService _socialDbService;
        private readonly IcoDbService _icoDbService;

        public IcoController(CoinTelegraphReader reader, CoinApi coinApi, IcoSocialDbService socialDbService, IcoDbService icoDbService)
        {
            _reader = reader;
            _coinApi = coinApi;
            _socialDbService = socialDbService;
            _icoDbService = icoDbService;
        }
        // GET: home/lasthour
        public ActionResult News()
        {
            var cnnItems = _reader.GetItems();
            ViewBag.News = cnnItems;
            return View();
        }

        public async Task<ActionResult> Live()
        {
            ViewBag.Title = $"Live ICOs";
            ViewBag.MetaDescription = $"A full list of ICOs, explore new icos, do your homework and invest as the Whales by starting your research here.";

            var icos = _icoDbService.GetLiveIcos();
            ViewBag.Icos = icos;

            var icosSocialImpact = new Dictionary<int, IcoSocialImpact>();
            foreach (var socialImpact in _socialDbService.GetIcoSocialImpacts())
            {
                if (!icosSocialImpact.ContainsKey(socialImpact.ProjID))
                {
                    icosSocialImpact.Add(socialImpact.ProjID, socialImpact);
                }
            }

            ViewBag.IcosSocialImpact = icosSocialImpact;
            return View();
        }

        public async Task<ActionResult> Upcomming()
        {
            ViewBag.Title = $"Upcomming ICOs";
            ViewBag.MetaDescription = $"A full list of ICOs, explore future icos, get ready to invest, do your homework and invest as the Whales by starting your research here.";

            var icos = _icoDbService.GetUpcommingIcos();
            ViewBag.Icos = icos;
            var icosSocialImpact = new Dictionary<int, IcoSocialImpact>();
            foreach (var socialImpact in _socialDbService.GetIcoSocialImpacts())
            {
                if (!icosSocialImpact.ContainsKey(socialImpact.ProjID))
                {
                    icosSocialImpact.Add(socialImpact.ProjID, socialImpact);
                }
            }
            ViewBag.IcosSocialImpact = icosSocialImpact;
            return View();
        }

        public ActionResult Details(string icoName)
        {
            if (string.IsNullOrEmpty(icoName))
            {
                return RedirectToAction("Live");
            }

            var icoDetailsName = icoName.Replace("_", " ");
            var icoDetails = _icoDbService.GetICoDetailByProjectName(icoDetailsName);
            var ico = _icoDbService.GetIcoByProjectName(icoDetailsName);
            ViewBag.IcoDetails = icoDetails;
            ViewBag.Ico = ico;
            return View();
        }
    }
}