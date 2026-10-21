using System.Data.Entity;
using CryptoMarketWeb.DataAccess.Entities;

namespace CryptoMarketWeb.DataAccess
{
    public class ExpertContext : DbContext
    {
        public ExpertContext()
            : base("ExpertContextDB")
        { }

        public DbSet<Expert> Experts { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}