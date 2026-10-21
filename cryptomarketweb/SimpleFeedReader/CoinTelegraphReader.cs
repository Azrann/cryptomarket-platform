using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace SimpleFeedReader
{
    public class CoinTelegraphReader
    {
        public IEnumerable<FeedItem> GetItems()
        {
            var result = new List<FeedItem>();
            WebClient client = new WebClient();
            var xmlPageString = client.DownloadString("https://cointelegraph.com/rss");
            byte[] bytes = Encoding.Default.GetBytes(xmlPageString);
            var xmlPage = Encoding.UTF8.GetString(bytes);
            var rssFeed = XElement.Parse(xmlPage);
            var items = rssFeed.Descendants("item");
            foreach (var item in items)
            {
                var elements = new List<XElement>(item.Elements());
                var categories = elements.Where(x => x.Name.LocalName == "category").Select(x => x.Value);
                result.Add(new FeedItem
                {
                    Title = item.Element("title").Value,
                    Date = DateTime.Parse(item.Element("pubDate").Value),
                    Uri = item.Element("link").Value,
                    Summary = RemoveImgTags(item.Element("description").Value),
                    Author = ((XText)(elements[5].FirstNode)).Value,
                    Image = elements[3].FirstAttribute.Value,
                    Categories = categories
                });
            };

            return result;
        }

        string RemoveImgTags(string html)
        {
            return Regex.Replace(html, "<img.+?>", string.Empty);
        }
    }
}
