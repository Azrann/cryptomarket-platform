using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoMarketWeb.DataAccess.Entities
{
    public class TweetViewPerDay 
    {
        public TweetViewPerDay()
        {
        }

        public static string GetId(string key, DateTime date)
        {
            return $"{key}-{date.ToShortDateString()}";
        }
        public int RetweetCount { get; set; }
        public int TweetCount { get; set; }
        public int Total { get; set; }

        [StringLength(20)]
        public string Key { get; set; }
        [StringLength(10)]
        public string Date { get; set; }

    }

    public class TweetViewPerDayWithIncrement : TweetViewPerDay
    {
        public int LastHour { get; set; }
        public decimal IncreasePercentage { get; set; }
    }
}
