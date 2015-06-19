using System;
using System.Collections.Generic;
using Entity.Interface;

namespace ORM.Models
{
    public partial class Answer : IEntity
    {
        public Answer()
        {
            this.GivenAnswers = new List<GivenAnswer>();
        }

        public int Id { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
        public int IsRight { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<GivenAnswer> GivenAnswers { get; set; }
    }
}
