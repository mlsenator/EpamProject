using System;
using System.Collections.Generic;
using Entity.Interface;

namespace DAL.Interface.DTO
{
    public partial class DALAnswer : IEntity
    {
        public DALAnswer()
        {
            this.GivenAnswers = new List<DALGivenAnswer>();
        }

        public int Id { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
        public bool IsRight { get; set; }
        public virtual DALQuestion Question { get; set; }
        public virtual ICollection<DALGivenAnswer> GivenAnswers { get; set; }
    }
}
