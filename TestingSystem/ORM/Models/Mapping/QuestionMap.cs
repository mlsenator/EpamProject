using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ORM.Models.Mapping
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.QuestionText)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Question");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.QuestionText).HasColumnName("QuestionText");
            this.Property(t => t.TestId).HasColumnName("TestId");

            // Relationships
            this.HasRequired(t => t.Test)
                .WithMany(t => t.Questions)
                .HasForeignKey(d => d.TestId).WillCascadeOnDelete(true);

        }
    }
}
