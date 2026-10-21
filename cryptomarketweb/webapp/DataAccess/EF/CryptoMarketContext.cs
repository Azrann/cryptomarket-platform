using System.Data.Entity;
using CryptoMarketWeb.DataAccess.Entities;

namespace CryptoMarketWeb.DataAccess
{
    public class CryptoMarketContext : DbContext
    {
        public CryptoMarketContext()
            : base("CryptoMarketDB")
        {

        }

        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<TweetViewPerDay> TweetsViewPerDay { get; set; }
        public DbSet<TweetViewPerHour> TweetsViewPerHour { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}