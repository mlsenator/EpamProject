using System;
using System.Collections.Generic;
using Entity.Interface;
using System.ComponentModel;

namespace BLL.Interface.Entities
{
    public partial class BLLGivenAnswer : IEntity
    {
        public int Id { get; set; }
        public int TestResultId { get; set; }
        public int AnswerId { get; set; }
        public virtual BLLAnswer Answer { get; set; }
        public virtual BLLTestResult TestResult { get; set; }
    }
}
