using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using CryptoMarketWeb.DataAccess;
using CryptoMarketWeb.Models.Sitemap;

namespace CryptoMarketWeb.Services
{
    public class SitemapService
    {
        private readonly IcoDbService _icoDbService;

        public SitemapService(IcoDbService icoDbService)
        {
            _icoDbService = icoDbService;
        }

        public IReadOnlyCollection<SitemapNode> GetSitemapNodes(UrlHelper urlHelper)
        {
            var excluded = new List<string>()
            {
                "C Ξ Y B I T",
                "re:factor"
            };
            List<SitemapNode> nodes = new List<SitemapNode>();
            nodes.Add(
                new SitemapNode()
                {
                    Url = urlHelper.AbsoluteRouteUrl("Icos"),
                    Priority = 1
                });
            nodes.Add(
                new SitemapNode()
                {
                    Url = urlHelper.AbsoluteRouteUrl("Default", new { controller = "Market" , action = "Last24hours" }),
                    Priority = 0.9
                });
            nodes.Add(
                new SitemapNode()
                {
                    Url = urlHelper.AbsoluteRouteUrl("Default", new { controller = "Expert", action = "Ico" }),
                    Priority = 0.9
                });
            nodes.Add(
                new SitemapNode()
                {
                    Url = urlHelper.AbsoluteRouteUrl("Default", new { controller = "Expert", action = "crypto" }),
                    Priority = 0.9
                });
            foreach (var ico in _icoDbService.GetIcos())
             {
                 if (!excluded.Contains(ico.ProjName))
                 {
                     nodes.Add(
                         new SitemapNode()
                         {
                             Url = urlHelper.AbsoluteRouteUrl("IcoDetails",
                                 new {icoName = ico.ProjName.Replace(".", "__").Replace(" ", "_")}),
                             Frequency = SitemapFrequency.Weekly,
                             Priority = 0.8
                         });
                 }
             }
            return nodes;
        }

        public string GetSitemapDocument(IEnumerable<SitemapNode> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                    sitemapNode.LastModified == null ? null : new XElement(
                        xmlns + "lastmod",
                        sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    sitemapNode.Frequency == null ? null : new XElement(
                        xmlns + "changefreq",
                        sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();
        }
    }
}