using System;
using System.Collections.Generic;
using Entity.Interface;

namespace ORM.Models
{
    public partial class Question : IEntity
    {
        public Question()
        {
            this.Answers = new List<Answer>();
        }

        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int TestId { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual Test Test { get; set; }
    }
}
