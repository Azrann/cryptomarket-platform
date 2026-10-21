using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoMarketAnalysis.DataAccess.Entities
{
    public class TweetViewPerDay : Entity<string>
    {
        public TweetViewPerDay(string key, DateTime date) : base(GetId(key, date))
        {
            Key = key;
        }

        public TweetViewPerDay() 
        {
        }

        public static string GetId(string key, DateTime date)
        {
            return $"{key}-{date.ToShortDateString()}";
        }
        public int RetweetCount { get; set; }
        public int TweetCount { get;  set; }

        [StringLength(20)]
        public string Key { get; set; }
        [StringLength(10)]
        public string Date { get; set; }
    }
}
