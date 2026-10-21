using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;

namespace SimpleFeedReader
{
    public class FeedItem
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Summary { get; set; }

        public string Uri { get; set; }

        public string Image { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public DateTimeOffset Date { get; set; }

        public string Author { get; set; }

    }
}
