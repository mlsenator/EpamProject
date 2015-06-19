using System;
using System.Collections.Generic;
using Entity.Interface;

namespace ORM.Models
{
    public partial class TestResult : IEntity
    {
        public TestResult()
        {
            this.GivenAnswers = new List<GivenAnswer>();
        }

        public int Id { get; set; }
        public int TestId { get; set; }
        public int UserId { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime FinishTime { get; set; }
        public int Result { get; set; }
        public virtual ICollection<GivenAnswer> GivenAnswers { get; set; }
        public virtual Test Test { get; set; }
        public virtual User User { get; set; }
    }
}
