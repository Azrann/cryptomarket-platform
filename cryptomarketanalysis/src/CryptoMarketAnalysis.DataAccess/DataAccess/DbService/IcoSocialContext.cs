using System.Data.Entity;
using CryptoMarketAnalysis.DataAccess.DataAccess.Entities;

namespace CryptoMarketAnalysis.DataAccess.DataAccess.DbService
{
    public class IcoSocialContext : DbContext
    {
        public IcoSocialContext()
            : base("IcoSocialDB")
        {

        }

        public DbSet<IcoSocialImpact> IcoSocialImpacts { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}