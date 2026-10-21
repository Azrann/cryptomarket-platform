using CryptoMarketAnalysis.DataAccess.Entities;
using System.Data.Entity;

namespace CryptoMarketAnalysis.DataAccess
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext()
            : base("CurrencyContextDB")
        {}

        public DbSet<CurrencyInfo> CurrenciesInfo { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyInfo>().Property(x => x.price_usd).HasPrecision(15, 8);
            modelBuilder.Entity<CurrencyInfo>().Property(x => x.price_btc).HasPrecision(15, 8);
            modelBuilder.Entity<CurrencyInfo>().Property(x => x.percent_change_1h).HasPrecision(5, 2);
            modelBuilder.Entity<CurrencyInfo>().Property(x => x.percent_change_24h).HasPrecision(5, 2);
            modelBuilder.Entity<CurrencyInfo>().Property(x => x.percent_change_7d).HasPrecision(5, 2);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}