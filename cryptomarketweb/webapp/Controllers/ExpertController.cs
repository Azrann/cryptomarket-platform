#region Using

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CryptoMarketWeb.DataAccess;
using SimpleFeedReader;

#endregion

namespace SmartAdminMvc.Controllers
{
    public class ExpertController : Controller
    {
        private readonly ExpertDbService _service;
        public ExpertController(ExpertDbService service)
        {
            _service = service;
        }

        public ActionResult Ico()
        {
            ViewBag.Title = $"ICOs expert list";
            ViewBag.MetaDescription = $"Full listing of experts in the ICOs world, follow them and stay ahead of the game.";

            var experts = _service.GetIcoExperts();
            ViewBag.Experts = experts;
            return View();
        }

        public ActionResult Crypto()
        {
            ViewBag.Title = $"Cryptocurrency expert list";
            ViewBag.MetaDescription = $"Full listing of experts in the cripto world, follow them and stay ahead of the game.";
            
            var experts = _service.GetCryptoExperts();
            ViewBag.Experts = experts;
            return View();
        }
    }
}