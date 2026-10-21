using System;
using System.Collections.Generic;
using System.Linq;
using CryptoMarketAnalysis.DataAccess.Entities;
using System.Data.SqlClient;
using Dapper.Contrib;
using Dapper;
using System.Data;

namespace CryptoMarketAnalysis.DataAccess
{
    public class DapperTweetDbService
    {
        private SqlConnection conn;
        private string connectionString;

        public DapperTweetDbService()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CryptoMarketDB"]
                .ConnectionString;
        }

        #region Tweets

        public void AddTweet(Tweet tweet)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                conn.Execute(@"SET IDENTITY_INSERT Tweets ON insert into Tweets(Id
               ,[Url]
               ,[FullText]
               ,[Author]
               ,[CreatedOn]
               ,[LastUpdated])
                    values (@Id, @Url, @FullText, @Author,@CreatedOn, @LastUpdated); 
                    ",
                    new {tweet.Id, tweet.Url, tweet.FullText, tweet.Author, tweet.CreatedOn, tweet.LastUpdated});
            }
        }

        #endregion

        #region TweetViewPerDay

        public void TweetViewIncrementTweet(string key, DateTime createdAt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var tweetViewPerHourId = TweetViewPerHour.GetId(key, createdAt);
                var tweetViewPerDayId = TweetViewPerDay.GetId(key, createdAt);
                var updatedAt = createdAt;
                conn.Execute("IncrementTweet",
                    new
                    {
                        Id = tweetViewPerDayId,
                        IdHour = tweetViewPerHourId,
                        Key = key,
                        CreatedOn = createdAt,
                        LastUpdate = updatedAt
                    }, commandType: CommandType.StoredProcedure);
            }
        }

        public void TweetViewIncrementReTweet(string key, DateTime createdAt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var tweetViewPerHourId = TweetViewPerHour.GetId(key, createdAt);
                var tweetViewPerDayId = TweetViewPerDay.GetId(key, createdAt);
                var updatedAt = createdAt;
                conn.Execute("IncrementReTweet",
                    new
                    {
                        Id = tweetViewPerDayId,
                        IdHour = tweetViewPerHourId,
                        Key = key,
                        CreatedOn = createdAt,
                        LastUpdate = updatedAt
                    }, commandType: CommandType.StoredProcedure);
            }
        }

        #endregion*/
    }
}