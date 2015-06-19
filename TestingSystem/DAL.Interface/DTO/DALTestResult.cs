using System;
using System.Collections.Generic;
using Entity.Interface;

namespace DAL.Interface.DTO
{
    public partial class DALTestResult : IEntity
    {
        public DALTestResult()
        {
            this.GivenAnswers = new List<DALGivenAnswer>();
        }

        public int Id { get; set; }
        public int TestId { get; set; }
        public int UserId { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime FinishTime { get; set; }
        public int Result { get; set; }
        public virtual ICollection<DALGivenAnswer> GivenAnswers { get; set; }
        public virtual DALTest Test { get; set; }
        public virtual DALUser User { get; set; }
    }
}
