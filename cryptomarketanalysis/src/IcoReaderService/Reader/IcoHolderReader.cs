using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using CryptoMarketAnalysis.DataAccess.DataAccess.Dtos;
using Newtonsoft.Json;

namespace IcoReaderService.Reader
{
    public class IcoHolderReader
    {
        private const string Url = "https://icoholder.com/en/icos/ongoing?sort=r.general&direction=desc&page=";
        private const string UpcommingUrl = "https://icoholder.com/en/icos/upcoming?sort=r.general&direction=desc&page=";

        public static void Read()
        {
            Random rnd = new Random();
            for (int i = 1; i < 71; i++)
            {
                Console.WriteLine($"Reading Page {i}");
                var result = ReadPage(i, Url).Result;
                var random = rnd.Next(10);
                Console.WriteLine($"Waiting {1000 + random * 486} milliseconds");
                Thread.Sleep(5000 + random * 486);
                Console.Clear();
            }
            
           rnd = new Random();
            for (int i = 1; i < 34; i++)
            {
                Console.WriteLine($"Reading Page {i}");
                var result = ReadPage(i, UpcommingUrl,53).Result;
                var random = rnd.Next(10);
                Console.WriteLine($"Waiting {1000 + random * 486} milliseconds");
                Thread.Sleep(5000 + random * 486);
                Console.Clear();
            }
        }

        public static async Task<bool> ReadPage(int i, string Url, int offset = 0)
        {
            List<IcoHolderItem> result = new List<IcoHolderItem>();

            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync($"{Url}{i}");
            var cellSelector = ".ico-list-row";
            var cells = document.QuerySelectorAll(cellSelector);

            foreach (var element in cells)
            {
                try
                {
                    IcoHolderItem item = new IcoHolderItem();
                    var imgElem = element.QuerySelector(".ico-list-logo img");
                    if (imgElem != null)
                    {
                        item.ImgUrl = imgElem.GetAttribute("src");
                    }

                    var aElem = element.QuerySelector(".ico-list-name-d a");
                    item.Url = aElem.GetAttribute("href");
                    item.ProjName = aElem.InnerHtml;
                    

                    var dateFromElem = element.QuerySelector(".ico-list-date-from");
                    if (dateFromElem != null)
                    { 
                        item.EventStartDate = GetStartDateFromString(dateFromElem.InnerHtml);

                        var dateEndElem = element.QuerySelector(".ico-list-date-to");
                        item.EventEndDate = GetEndDateFromString(dateEndElem.InnerHtml);
                    }

                    var percentElem = element.QuerySelector(".ico-list-period-value");
                    if (percentElem != null)
                    {
                        item.Percent = double.Parse(percentElem.InnerHtml.Replace("% completed", ""));
                    }
                    
                    //TODO: Read here date and percent.
                    // Run to generate the files
                    // Run to read from files and insert in DB

                    result.Add(item);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }

            System.IO.File.WriteAllText(
                @"logs\IcoHolder\IcoHolder" + (i+ offset) + ".txt", JsonConvert.SerializeObject(result));
            return true;
        }

        private static DateTime? GetStartDateFromString(string dateString)
        {
            
            if (dateString.Length == 11)
            {
                return ParseDate(dateString, "MMM d, yyyy");
            }

            if (dateString.Length == 12)
            {
                return ParseDate(dateString, "MMM dd, yyyy");
            }
            return ParseDate(dateString, "MMM, yyyy");
        }

        private static DateTime? GetEndDateFromString(string dateString)
        {
            if (dateString.Length > 10)
            {
                return ParseDate(dateString, "MMM dd, yyyy");
            }

            var result = ParseDate(dateString, "MMM, yyyy");
            return result?.AddMonths(1).AddDays(-1);
        }

        private static DateTime? ParseDate(string dateString, string format)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            try
            {
                return DateTime.ParseExact(dateString, format, provider);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
