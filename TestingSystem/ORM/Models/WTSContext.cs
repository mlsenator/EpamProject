using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ORM.Models.Mapping;
using ORM;

namespace ORM.Models
{
    public partial class WTSContext : DbContext, IDataContext
    {
        static WTSContext()
        {
            Database.SetInitializer<WTSContext>(null);
        }

        public WTSContext()
            : base("Name=WTSContext")
        {
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<GivenAnswer> GivenAnswers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnswerMap());
            modelBuilder.Configurations.Add(new GivenAnswerMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new TestMap());
            modelBuilder.Configurations.Add(new TestResultMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
