using System.Data.Entity;
using CryptoMarketWeb.DataAccess.Entities;

namespace CryptoMarketWeb.DataAccess
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext()
            : base("CurrencyContextDB")
        { }

        public DbSet<Suggestion> Suggestions { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}