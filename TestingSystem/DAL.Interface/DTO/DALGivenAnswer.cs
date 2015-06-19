using System;
using System.Collections.Generic;
using Entity.Interface;

namespace DAL.Interface.DTO
{
    public partial class DALGivenAnswer : IEntity
    {
        public int Id { get; set; }
        public int TestResultId { get; set; }
        public int AnswerId { get; set; }
        public virtual DALAnswer Answer { get; set; }
        public virtual DALTestResult TestResult { get; set; }
    }
}
