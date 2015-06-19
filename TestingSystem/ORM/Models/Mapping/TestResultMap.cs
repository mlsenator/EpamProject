using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ORM.Models.Mapping
{
    public class TestResultMap : EntityTypeConfiguration<TestResult>
    {
        public TestResultMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TestResult");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TestId).HasColumnName("TestId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.StartTime).HasColumnName("StartTime");
            this.Property(t => t.FinishTime).HasColumnName("FinishTime");
            this.Property(t => t.Result).HasColumnName("Result");

            // Relationships
            this.HasRequired(t => t.Test)
                .WithMany(t => t.TestResults)
                .HasForeignKey(d => d.TestId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.TestResults)
                .HasForeignKey(d => d.UserId);

        }
    }
}
