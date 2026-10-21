using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CryptoMarketWeb.DataAccess;
using CryptoMarketWeb.Services;

namespace CryptoMarketWeb.Controllers
{
    public class SitemapController : Controller
    {
        public ActionResult Index()
        {
            SitemapService service = new SitemapService(new IcoDbService());
            var sitemapNodes = service.GetSitemapNodes(this.Url);
            string xml = service.GetSitemapDocument(sitemapNodes);
            return this.Content(xml, "text/xml", Encoding.UTF8);
        }
    }
}