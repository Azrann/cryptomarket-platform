using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CryptoMarketAnalysis.DataAccess.DataAccess;
using CryptoMarketAnalysis.DataAccess.DataAccess.DbService;
using CryptoMarketAnalysis.DataAccess.DataAccess.Entities;
using IcoReaderService.Reader;

namespace IcoHolderScrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            IcoDbService service = new IcoDbService();
            service.InitializeStoreProcs();
            GenerateIcoHolderFiles();
            PopulateDbFromFiles();
            Console.ReadKey();
        }

        private static void PopulateDbFromFiles(int startingPage = 1)
        {
            var context = new IcoMarketContext();
            IRepository<IcoProjectDetails> icoProjectDetailsRepo = new Repository<IcoProjectDetails>(context);
            IRepository<IcoProject> icoProjectRepo = new Repository<IcoProject>(context);
            IcoDbService service = new IcoDbService();

            int numFiles = Directory.GetFiles($@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\logs\IcoHolder").Length;
            IcoHolderFileReader reader = new IcoHolderFileReader();
            for (int i = startingPage; i <= numFiles; i++)
            {            
                Console.WriteLine($"Reading page {i}");
                var result = reader
                    .GetProjectsDetails(
                        $@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\logs\IcoHolder\IcoHolder{i}.txt")
                    .Result;
                foreach (var icoProjectDetails in result)
                {
                    service.Upsert(icoProjectDetails.Key);
                    service.Upsert(icoProjectDetails.Value);
                }

                Console.Clear();
            }
        }

        private static void GenerateIcoHolderFiles()
        {
            System.IO.Directory.CreateDirectory("logs\\IcoHolder");
            IcoHolderReader.Read();
        }
    }
}
