using BIED_research_suite.Models.Database_entities;
using Microsoft.EntityFrameworkCore;

namespace BIED_research_suite.Data
{
    public class QuestionnairesContext : DbContext
    {
        public QuestionnairesContext(DbContextOptions<QuestionnairesContext> options)
            : base(options)
        {
        }

        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<QuestionnaireSection> Sections { get; set; }
        public DbSet<QuestionnaireItem> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Questionnaire>().ToTable("Questionnaire");
            modelBuilder.Entity<QuestionnaireSection>().ToTable("Section");
            modelBuilder.Entity<QuestionnaireItem>().ToTable("Item");
        }
    }
}
