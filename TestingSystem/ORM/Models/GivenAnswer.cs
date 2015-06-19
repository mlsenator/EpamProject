using System;
using System.Collections.Generic;
using Entity.Interface;

namespace ORM.Models
{
    public partial class GivenAnswer : IEntity
    {
        public int Id { get; set; }
        public int TestResultId { get; set; }
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual TestResult TestResult { get; set; }
    }
}
