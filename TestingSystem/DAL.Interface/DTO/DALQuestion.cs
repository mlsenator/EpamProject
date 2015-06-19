using System;
using System.Collections.Generic;
using Entity.Interface;

namespace DAL.Interface.DTO
{
    public partial class DALQuestion : IEntity
    {
        public DALQuestion()
        {
            this.Answers = new List<DALAnswer>();
        }

        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int TestId { get; set; }
        public virtual ICollection<DALAnswer> Answers { get; set; }
        public virtual DALTest Test { get; set; }
    }
}
