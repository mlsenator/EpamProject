using System;
using System.Collections.Generic;
using Entity.Interface;
using System.ComponentModel;

namespace BLL.Interface.Entities
{
    public partial class BLLTestResult : IEntity
    {
        public BLLTestResult()
        {
            this.GivenAnswers = new List<BLLGivenAnswer>();
        }

        public int Id { get; set; }
        public int TestId { get; set; }
        public int UserId { get; set; }
        [DisplayName("Start time")]
        public System.DateTime StartTime { get; set; }
        [DisplayName("Finish time")]
        public System.DateTime FinishTime { get; set; }
        [DisplayName("Result in percents")]
        public int Result { get; set; }
        public virtual List<BLLGivenAnswer> GivenAnswers { get; set; }
        public virtual BLLTest Test { get; set; }
        public virtual BLLUser User { get; set; }
    }
}
