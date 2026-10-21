using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AutoMapper;
using CryptoMarketWeb.DataAccess.Entities;
using Dapper;

namespace CryptoMarketWeb.DataAccess
{
    public class TweetsDbService
    {
        private SqlConnection conn;
        private string connectionString;
        public TweetsDbService()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CryptoMarketDB"].ConnectionString;       
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
            var tweetViewPerHourId = TweetViewPerHour.GetId(key, createdAt);
            var tweetViewPerDayId = TweetViewPerDay.GetId(key, createdAt);
            var updatedAt = DateTime.UtcNow;
            conn.Execute("IncrementTweet", new { Id=tweetViewPerDayId, IdHour=tweetViewPerHourId, Key=key, CreatedOn=createdAt, LastUpdate=updatedAt }, commandType: CommandType.StoredProcedure); 
        }

        public void TweetViewIncrementReTweet(string key, DateTime createdAt)
        {
            var tweetViewPerHourId = TweetViewPerHour.GetId(key, createdAt);
            var tweetViewPerDayId = TweetViewPerDay.GetId(key, createdAt);
            var updatedAt = DateTime.UtcNow;
            conn.Execute("IncrementReTweet", new { Id = tweetViewPerDayId, IdHour = tweetViewPerHourId, Key = key, CreatedOn = createdAt, LastUpdate = updatedAt }, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<TweetViewPerDay> GetTopOfDay()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return conn.Query<TweetViewPerDay>(
                    "SELECT TOP 27 [Id] ,[RetweetCount] ,[TweetCount],[Key],[Date],[LastUpdated], [RetweetCount] +[TweetCount] as Total FROM [dbo].[TweetViewPerDays] Order By LastUpdated desc");
            }
        }

        public IEnumerable<TweetViewPerDay> GetTopOfHour()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return conn.Query<TweetViewPerDay>(
                    "SELECT TOP 81 [Id] ,[RetweetCount] ,[TweetCount],[Key],[Date],[LastUpdated], [RetweetCount] +[TweetCount] as Total FROM [dbo].[TweetViewPerHours] Order By LastUpdated desc");
            }
        }

        #endregion*/

        public IEnumerable<TweetViewPerDayWithIncrement> GetTopOfHourWithIncrement()
        {
            List<TweetViewPerDayWithIncrement>  result = new List<TweetViewPerDayWithIncrement>();

            foreach (var tweetViewPerDay in GetTopOfHour())
            {
                var tweetViewPerdayWithIncrement = result.FirstOrDefault(x => x.Key == tweetViewPerDay.Key);
                if (tweetViewPerdayWithIncrement != null)
                {
                    if (tweetViewPerdayWithIncrement.LastHour != 0 & tweetViewPerDay.Total > 0)
                    {
                        decimal percentage = 
                            ((tweetViewPerdayWithIncrement.LastHour - tweetViewPerDay.Total) * 100.0m) / tweetViewPerDay.Total;
                        tweetViewPerdayWithIncrement.IncreasePercentage =
                            decimal.Round(percentage, 2, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        tweetViewPerdayWithIncrement.LastHour = tweetViewPerDay.Total;
                    }
                }
                else
                {
                    var newTweetView = Mapper.Map<TweetViewPerDayWithIncrement>(tweetViewPerDay);
                    result.Add(newTweetView);
                }
            }
            return result;
        }


        public IEnumerable<CurrencyNumbers> GetTweetsLast24Hours()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return conn.Query<CurrencyNumbers>(@"SELECT distinct [Key] as Symbol,
                (
                    SELECT  CAST(([TweetCount] +[RetweetCount]) AS nvarchar(15)) + ','
                    FROM[TweetViewPerHours] t2
                    WHERE t2.[Key] = t1.[Key] AND CreatedOn > DATEADD(DAY, -1, GETUTCDATE())
                    ORDER BY CreatedOn
                    FOR XML PATH('')) as Numbers
                FROM[TweetViewPerHours] t1
                    WHERE CreatedOn > DATEADD(HOUR, -1, GETUTCDATE())");
            }
        }

        public Dictionary<string, TweetViewPerDayWithIncrement> GetTweetsViewLast24Hours()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var todaysTweet = conn.Query<TweetViewPerDayWithIncrement>(@"  
              SELECT [Key], SUM([TweetCount]) as [TweetCount], SUM([RetweetCount]) as RetweetCount, SUM([TweetCount]) + SUM([RetweetCount]) as Total
              FROM TweetViewPerHours
              WHERE [CreatedOn] > DATEADD(DAY, -1, GETUTCDATE())
              GROUP BY [Key]").ToDictionary(x => x.Key);

                var yesterdayTweets = conn.Query<TweetViewPerDay>(@"  
              SELECT [Key], SUM([TweetCount]) as [TweetCount], SUM([RetweetCount]) as RetweetCount, SUM([TweetCount]) + SUM([RetweetCount]) as Total
              FROM TweetViewPerHours
              WHERE [CreatedOn] > DATEADD(DAY, -2, GETUTCDATE()) AND [CreatedOn] < DATEADD(DAY, -1, GETUTCDATE())
              GROUP BY [Key]");
            

                foreach (var tweetView in yesterdayTweets)
                {
                    if (todaysTweet.ContainsKey(tweetView.Key))
                    {
                        decimal percentage =
                            ((todaysTweet[tweetView.Key].Total - tweetView.Total) * 100.0m) / tweetView.Total;
                        todaysTweet[tweetView.Key].IncreasePercentage =
                            decimal.Round(percentage, 2, MidpointRounding.AwayFromZero);
                    }
                }

                return todaysTweet;
            }
        }
    }
}
