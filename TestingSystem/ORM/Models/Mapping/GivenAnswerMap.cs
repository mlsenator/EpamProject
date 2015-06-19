using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ORM.Models.Mapping
{
    public class GivenAnswerMap : EntityTypeConfiguration<GivenAnswer>
    {
        public GivenAnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("GivenAnswers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TestResultId).HasColumnName("TestResultId");
            this.Property(t => t.AnswerId).HasColumnName("AnswerId");

            // Relationships
            this.HasRequired(t => t.Answer)
                .WithMany(t => t.GivenAnswers)
                .HasForeignKey(d => d.AnswerId);
            this.HasRequired(t => t.TestResult)
                .WithMany(t => t.GivenAnswers)
                .HasForeignKey(d => d.TestResultId);

        }
    }
}
