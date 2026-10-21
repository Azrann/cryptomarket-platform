using System.Web.Http;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CryptoMarketWeb.DataAccess;
using CryptoMarketWeb.DataAccess.Dapper;
using CryptoMarketWeb.DataAccess.Entities;
using CryptoMarketWeb.Services;
using SimpleFeedReader;

namespace CryptoMarketWeb
{
    public static class WindsorConfigurator
    {
        public static IWindsorContainer Configure(IWindsorContainer container)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleTransient());
            container.Register(Classes.FromThisAssembly().BasedOn<Controller>().LifestyleTransient());

            container.Register(Component.For<TweetsDbService>().Instance(new TweetsDbService()));
            container.Register(Component.For<CurrencyDbService>().Instance(new CurrencyDbService()));

            container.Register(Component.For<IRepository<Suggestion>>()
                .Instance(new Repository<Suggestion>(new CurrencyContext())));
            container.Register(Component.For<CoinTelegraphReader>().Instance(new CoinTelegraphReader()));

            container.Register(Component.For<IRepository<Expert>>()
                .Instance(new Repository<Expert>(new ExpertContext())));
            container.Register(Component.For<ExpertDbService>().Instance(new ExpertDbService()));

            container.Register(Component.For<CoinApi>().Instance(new CoinApi()));
            
            container.Register(Component.For<IcoSocialDbService>().Instance(new IcoSocialDbService()));
            container.Register(Component.For<IcoDbService>().Instance(new IcoDbService()));
            /*container.Register(Component.For<IStatsDPublisher>().ImplementedBy<StatsDPublisher>());
            container.Register(Component.For<DbContext>().ImplementedBy<CompanyContext>().LifestyleTransient());

            container.Register(Component.For<IRepository<Company>>().ImplementedBy<Repository<Company>>().LifestyleTransient());
            container.Register(Component.For<IRepository<Team>>().ImplementedBy<Repository<Team>>().LifestyleTransient());
            container.Register(Component.For<IRepository<Employee>>().ImplementedBy<Repository<Employee>>().LifestyleTransient());
            container.Register(Component.For<IServiceBus>().Instance(new AzureServiceBus(ConfigurationManager.AppSettings["Enviroment"], ConfigurationManager.AppSettings["Feature"], container.Resolve<IStatsDPublisher>())).LifestyleSingleton());

            container.Register(Component.For<IEventHandler<CompanyCreatedEvent>>().ImplementedBy<CompanyCreatedEventHandler>().LifestyleTransient());
            container.Register(Component.For<IEventHandler<EmployeeCreatedEvent>>().ImplementedBy<EmployeeCreatedEventHandler>().LifestyleTransient());
            container.Register(Component.For<IEventHandler<EmployeeUpdatedEvent>>().ImplementedBy<EmployeeUpdatedEventHandler>().LifestyleTransient());

            container.Register(Component.For<IEventHandler<TeamCreatedEvent>>().ImplementedBy<TeamCreatedEventHandler>().LifestyleTransient());
            container.Register(Component.For<IEventHandler<TeamRemovedEvent>>().ImplementedBy<TeamRemovedEventHandler>().LifestyleTransient());
            container.Register(Component.For<IMessageHandler<CompanyPingEvent>>().ImplementedBy<PingAsyncEventHandler<CompanyPingEvent>>().LifestyleTransient());
            */
            return container;
        }
    }
}