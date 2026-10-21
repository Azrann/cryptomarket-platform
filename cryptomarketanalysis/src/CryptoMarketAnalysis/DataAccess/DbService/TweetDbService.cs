using System;
using System.Collections.Generic;
using System.Linq;
using CryptoMarketAnalysis.DataAccess.Entities;

namespace CryptoMarketAnalysis.DataAccess
{
    public class TweetDbService
    {
        private IRepository<Tweet> tweetsRepo;
        private IRepository<TweetViewPerDay> tweetsViewPerDayRepo;
        private IRepository<TweetViewPerHour> tweetsViewPerHourRepo;


        public TweetDbService()
        {
            var cryptoMarketContext = new CryptoMarketContext();
            tweetsRepo = new Repository<Tweet>(cryptoMarketContext);
            tweetsViewPerDayRepo = new Repository<TweetViewPerDay>(cryptoMarketContext);
            tweetsViewPerHourRepo = new Repository<TweetViewPerHour>(cryptoMarketContext);
        }

        #region Tweets

        public void AddTweet(Tweet tweet)
        {
            var result = tweetsRepo.Add(tweet);
            tweetsRepo.Save();
        }

        public IEnumerable<Tweet> GetTweetById(long id)
        {
            return tweetsRepo.GetAll(x => x.Id == id);
        }

        #endregion

        #region TweetViewPerDay

        public void TweetViewPerDayIncrementTweet(string key, DateTime createdAt)
        {
            var tweetViewPerDayId = TweetViewPerDay.GetId(key, createdAt);
            var tweetViewPerDay = GetTweetViewPerDayById(tweetViewPerDayId);
            if (tweetViewPerDay == null)
            {
                tweetsViewPerDayRepo.Add(new TweetViewPerDay(key, createdAt)
                {
                    TweetCount = 1
                });
            }
            else {
                tweetViewPerDay.TweetCount++;
                tweetsViewPerDayRepo.Update(tweetViewPerDay);
            }
            tweetsViewPerDayRepo.Save();
        }

        public void TweetViewPerDayIncrementReTweet(string key, DateTime createdAt)
        {
            var tweetViewPerDayId = TweetViewPerDay.GetId(key, createdAt);
            var tweetViewPerDay = GetTweetViewPerDayById(tweetViewPerDayId);
            if (tweetViewPerDay == null)
            {
                tweetViewPerDay = new TweetViewPerDay(key, createdAt)
                {
                    RetweetCount = 1
                };
                tweetsViewPerDayRepo.Add(tweetViewPerDay);
            }
            else
            {
                tweetViewPerDay.RetweetCount++;
                tweetsViewPerDayRepo.Update(tweetViewPerDay);
            }
            tweetsViewPerDayRepo.Save();
        }

        public TweetViewPerDay GetTweetViewPerDayById(string id)
        {
            return tweetsViewPerDayRepo.GetAll(x => x.Id == id).ToList().FirstOrDefault();
        }

        #endregion

        #region TweetViewPerHour

        public void TweetViewPerHourIncrementTweet(string key, DateTime createdAt)
        {
            var tweetViewPerHourId = TweetViewPerHour.GetId(key, createdAt);
            var tweetViewPerHour = GetTweetViewPerHourById(tweetViewPerHourId);
            if (tweetViewPerHour == null)
            {
                tweetsViewPerHourRepo.Add(new TweetViewPerHour(key, createdAt)
                {
                    TweetCount = 1
                });
            }
            else
            {
                tweetViewPerHour.TweetCount++;
                tweetsViewPerHourRepo.Update(tweetViewPerHour);
            }
            tweetsViewPerHourRepo.Save();
        }

        public void TweetViewPerHourIncrementReTweet(string key, DateTime createdAt)
        {
            var tweetViewPerHourId = TweetViewPerHour.GetId(key, createdAt);
            var tweetViewPerHour = GetTweetViewPerHourById(tweetViewPerHourId);
            if (tweetViewPerHour == null)
            {
                tweetsViewPerHourRepo.Add(new TweetViewPerHour(key, createdAt)
                {
                    RetweetCount = 1
                });
            }
            else
            {
                tweetViewPerHour.RetweetCount++;
                tweetsViewPerHourRepo.Update(tweetViewPerHour);
            }
            tweetsViewPerHourRepo.Save();
        }

        public TweetViewPerHour GetTweetViewPerHourById(string id)
        {
            return tweetsViewPerHourRepo.GetAll(x => x.Id == id).ToList().FirstOrDefault();
        }

        #endregion
    }
}
