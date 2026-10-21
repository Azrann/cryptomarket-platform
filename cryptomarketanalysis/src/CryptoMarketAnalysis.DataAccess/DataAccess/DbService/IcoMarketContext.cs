using System.Data.Entity;
using CryptoMarketAnalysis.DataAccess.DataAccess.Entities;

namespace CryptoMarketAnalysis.DataAccess.DataAccess.DbService
{
    public class IcoMarketContext : DbContext
    {
        public IcoMarketContext()
            : base("IcoMarketDB")
        {
        }

        public DbSet<IcoProject> IcoProjects { get; set; }
        public DbSet<IcoProjectDetails> IcoProjectsDetails { get; set; }
        public DbSet<IcoLinks> IcoLinks { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IcoProjectDetails>().ToTable("IcoProjectDetails");
        }
    }
}