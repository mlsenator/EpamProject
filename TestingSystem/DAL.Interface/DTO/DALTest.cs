using System;
using System.Collections.Generic;
using Entity.Interface;

namespace DAL.Interface.DTO
{
    public partial class DALTest : IEntity
    {
        public DALTest()
        {
            this.Questions = new List<DALQuestion>();
            this.TestResults = new List<DALTestResult>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public System.TimeSpan Duration { get; set; }
        public virtual ICollection<DALQuestion> Questions { get; set; }
        public virtual ICollection<DALTestResult> TestResults { get; set; }
    }
}
