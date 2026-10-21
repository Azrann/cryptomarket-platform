#region Using

using System.Web.Mvc;
using System.Web.Routing;
using SmartAdminMvc;

#endregion

namespace CryptoMarketWeb
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;
            routes.MapRoute(
                "Sitemap",
                "sitemap.xml",
                new { controller = "Sitemap", action = "Index" }
            );

            routes.MapRoute("Icos", "Icos", new
            {
                controller = "Icos",
                action = "Index",
                id = UrlParameter.Optional
            }).RouteHandler = new DashRouteHandler();

            routes.MapRoute("CryptocurrenciesDetails", "Cryptocurrencies/{cryptoName}", new
            {
                controller = "Cryptocurrencies",
                action = "Details"
            }).RouteHandler = new DashRouteHandler();

            routes.MapRoute("IcoDetails", "Icos/{icoName}", new
            {
                controller = "Icos",
                action = "Details"
            }).RouteHandler = new DashRouteHandler();
            routes.MapRoute("Default", "{controller}/{action}/{id}", new
            {
                controller = "market",
                action = "last24hours",
                id = UrlParameter.Optional
            }).RouteHandler = new DashRouteHandler();
        }
    }
}