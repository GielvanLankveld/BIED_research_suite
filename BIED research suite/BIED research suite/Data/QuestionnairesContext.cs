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
        public DbSet<QuestionnaireSection> QuestionnaireSections { get; set; }
        public DbSet<QuestionnaireItem> QuestionnaireItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Questionnaire>().ToTable("Questionnaire");
            modelBuilder.Entity<QuestionnaireSection>().ToTable("QuestionnaireSection");
            modelBuilder.Entity<QuestionnaireItem>().ToTable("QuestionnaireItem");
        }
    }
}
