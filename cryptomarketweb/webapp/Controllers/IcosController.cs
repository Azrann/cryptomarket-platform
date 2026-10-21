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
    public class IcosController : Controller
    {
        private CoinTelegraphReader _reader;
        private readonly CoinApi _coinApi;
        private readonly IcoSocialDbService _socialDbService;
        private readonly IcoDbService _icoDbService;

        public IcosController(CoinTelegraphReader reader, CoinApi coinApi, IcoSocialDbService socialDbService, IcoDbService icoDbService)
        {
            _reader = reader;
            _coinApi = coinApi;
            _socialDbService = socialDbService;
            _icoDbService = icoDbService;
        }

        // GET: icos
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = $"ICOs as a full list with Ratings";
            ViewBag.MetaDescription = $"A full list of ICOs, explore new icos, do your homework and invest as the Whales by starting your research here.";

            var icos = _icoDbService.GetIcos();
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
            ViewBag.Title = $"{icoName} fundamental analysis";
            ViewBag.MetaDescription = $"All you need to Know about {icoName}. Extensive fundamental Analysis with roadmap, video, description, Team, and RATINGS.";
            if (string.IsNullOrEmpty(icoName))
            {
                return RedirectToAction("Index");
            }

            var icoDetailsName = icoName.Replace("__", ".").Replace("_", " ");
            var icoDetails = _icoDbService.GetICoDetailByProjectName(icoDetailsName);
            var ico = _icoDbService.GetIcoByProjectName(icoDetailsName);
            ViewBag.IcoDetails = icoDetails;
            ViewBag.Ico = ico;
            return View();
        }
    }
}