using BIED_research_suite.Models.Database_entities;
using Microsoft.EntityFrameworkCore;

namespace BIED_research_suite.Data
{
    public class DatasetsContext : DbContext
    {
        public DatasetsContext(DbContextOptions<DatasetsContext> options)
            : base(options)
        {
        }

        public DbSet<Dataset> Datasets { get; set; }
        public DbSet<Response> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dataset>().ToTable("Dataset");
            modelBuilder.Entity<Response>().ToTable("Response");
        }
    }
}
