using System;
using System.Linq;
using System.Threading;
using CronNET;
using CryptoMarketAnalysis.DataAccess.DataAccess;
using CryptoMarketAnalysis.DataAccess.DataAccess.DbService;
using CryptoMarketAnalysis.DataAccess.DataAccess.Entities;
using IcoReaderService.Reader;

namespace IcoReaderService
{
    class Program
    {
        private static readonly CronDaemon CronDaemon = new CronDaemon();
        static void Main(string[] args)
        {
            //AddAllUpCommingIcos();
            //AddAllLiveIcos();
            //AddIcoLinks();

            Console.WriteLine("Starting CRON JOBS...");
            CronDaemon.AddJob("1 * * * *", UpdateSocialImpact);
            CronDaemon.Start();
            // Wait and sleep forever. Let the cron daemon run.
            while (true) Thread.Sleep(6000);
        }

        private static void UpdateSocialImpact()
        {
            IcoDbService service = new IcoDbService();
            var links = service.GetIcoLinksExcludingEmpty();

            IRepository<IcoSocialImpact> repo = new Repository<IcoSocialImpact>(new IcoSocialContext());
            int total = links.Count();
            int count = 0;
            foreach (var icoLinks in links)
            {
                Console.WriteLine($"Completed {count}/{total}");
                Console.WriteLine($"Reading social from {icoLinks.ProjName}");
                try
                {
                    var socialImpact = SocialReader.GetImpact(icoLinks).Result;
                    var icoSocialImpact = new IcoSocialImpact(icoLinks);
                    icoSocialImpact.Set(socialImpact);
                    repo.Add(icoSocialImpact);
                }
                catch (Exception e)
                {
                }
                Console.WriteLine($"Saving {icoLinks.ProjName}");
                try
                {
                    repo.Save();
                }
                catch (Exception e)
                {
                }
                Console.Clear();
                count++;
            }
            Console.WriteLine($"Last updated: {DateTime.UtcNow}");
        }

        // TODO How to add links now
        //private static void AddIcoLinks()
        //{
        //    IcoDbService service = new IcoDbService();
        //    var icos = service.GetAllIcos();

        //    IRepository<IcoLinks> repo = new Repository<IcoLinks>(new IcoMarketContext());
        //    Console.WriteLine("Transforming.");

        //    var icolinks = service.GetIcoLinks();

        //    foreach (var icoProject in icos)
        //    {
        //        Console.WriteLine($"Retrieving {icoProject.ProjName}");
        //        if (!icolinks.Any(x => x.ProjID == icoProject.ProjID))
        //        {
        //            var result = ProjectDetailsReader.Read(icoProject.ProjURL).Result;
        //            IcoLinks icoLink = new IcoLinks(icoProject);
        //            icoLink.SetLinks(result.Links);
        //            repo.Add(icoLink);
        //            Thread.Sleep(1000);
        //            Console.Clear();
        //            Console.WriteLine($"Saving {icoProject.ProjName}");
        //            repo.Save();
        //        }
        //    }
        //}

        /*private static void AddAllUpCommingIcos()
        {
            CoinApi api = new CoinApi();
            var liveIcos = api.GetAllUpCommingCoins().Result;

            IRepository<IcoProject> repo = new Repository<IcoProject>(new IcoMarketContext());
            int count = 0;
            foreach (var crowdfund in liveIcos)
            {
                count++;
                Console.Clear();
                Console.WriteLine($"{count} : Adding {crowdfund.ProjName}");
                repo.Add(new IcoProject(crowdfund));
            }
            Console.WriteLine("Saving Upcomming ICOs.");
            repo.Save();
            Console.WriteLine("Upcomming ICOs Added");
        }

        private static void AddAllLiveIcos()
        {
            CoinApi api = new CoinApi();
            var liveIcos = api.GetAllLiveCoins().Result;

            IRepository<IcoProject> repo = new Repository<IcoProject>(new IcoMarketContext());
            int count = 0;
            foreach (var crowdfund in liveIcos)
            {
                count++;
                Console.Clear();
                Console.WriteLine($"{count} : Adding {crowdfund.ProjName}");
                repo.Add(new IcoProject(crowdfund));
            }
            Console.WriteLine("Saving Live ICOs.");
            repo.Save();
            Console.WriteLine("Live ICOs Added");
        }*/
    }
}
