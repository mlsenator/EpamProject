using System;
using System.Collections.Generic;
using Entity.Interface;

namespace ORM.Models
{
    public partial class Test : IEntity
    {
        public Test()
        {
            this.Questions = new List<Question>();
            this.TestResults = new List<TestResult>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public System.TimeSpan Duration { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}
