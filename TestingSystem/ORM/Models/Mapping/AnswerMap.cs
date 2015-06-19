using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ORM.Models.Mapping
{
    public class AnswerMap : EntityTypeConfiguration<Answer>
    {
        public AnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.AnswerText)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Answer");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AnswerText).HasColumnName("AnswerText");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.IsRight).HasColumnName("IsRight");

            // Relationships
            this.HasRequired(t => t.Question)
                .WithMany(t => t.Answers)
                .HasForeignKey(d => d.QuestionId).WillCascadeOnDelete(true);

        }
    }
}
