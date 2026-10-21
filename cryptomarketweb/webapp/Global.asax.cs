#region Using

using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using CryptoMarketWeb;
using CryptoMarketWeb.DataAccess.Entities;
using SmartAdminMvc.Models;
using WebApiContrib.IoC.CastleWindsor;

#endregion

namespace SmartAdminMvc
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas(); 
            GlobalConfiguration.Configure(WebApiConfig.Register);
            WindsorConfigurator.Configure(ContainerManager.Container);
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorResolver(ContainerManager.Container);
            var controllerFactory = new WindsorControllerFactory(ContainerManager.Container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            IdentityConfig.RegisterIdentities();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TweetViewPerDay, TweetViewPerDayWithIncrement>();
                cfg.CreateMap<AccountRegistrationModel, Expert>();
            });
        }
    }
}