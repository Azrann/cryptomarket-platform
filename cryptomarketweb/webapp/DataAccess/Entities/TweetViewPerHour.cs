using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoMarketWeb.DataAccess.Entities
{
    public class TweetViewPerHour : Entity<string>
    {
        public TweetViewPerHour(string key, DateTime date) : base(GetId(key, date))
        {
            Key = key;
        }

        public TweetViewPerHour()
        {
        }

        public static string GetId(string key, DateTime date)
        {
            return $"{key}-{date.ToShortDateString()}-{date.Hour}";
        }
        public int RetweetCount { get; set; }
        public int TweetCount { get; set; }
        [StringLength(20)]
        public string Key { get; set; }
        [StringLength(10)]
        public string Date { get; set; }
        public Int16 Hour { get; set; }
    }
}
