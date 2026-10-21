using System.Collections.Generic;
using CryptoMarketWeb.DataAccess.Entities;

namespace CryptoMarketWeb.DataAccess
{
    public class DbService
    {
        private IRepository<Tweet> tweetsRepo;
        private IRepository<TweetViewPerHour> tweetsViewPerHourRepo;


        public DbService()
        {
            var cryptoMarketContext = new CryptoMarketContext();
            tweetsRepo = new Repository<Tweet>(cryptoMarketContext);
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

    }
}
