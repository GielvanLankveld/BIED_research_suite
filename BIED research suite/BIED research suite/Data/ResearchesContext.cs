using BIED_research_suite.Models.Database_entities;
using Microsoft.EntityFrameworkCore;

namespace BIED_research_suite.Data
{
    public class ResearchesContext : DbContext
    {
        public ResearchesContext(DbContextOptions<ResearchesContext> options)
            : base(options)
        {
        }

        public DbSet<Research> Researches { get; set; }
        public DbSet<ResearchPhase> ResearchePhases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Research>().ToTable("Research");
            modelBuilder.Entity<ResearchPhase>().ToTable("ResearchPhase");
        }

        public DbSet<BIED_research_suite.Models.Database_entities.Dataset> Dataset { get; set; }
    }
}
