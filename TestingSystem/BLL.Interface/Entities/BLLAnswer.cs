using System;
using System.Collections.Generic;
using Entity.Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 

namespace BLL.Interface.Entities
{
    public partial class BLLAnswer : IEntity
    {
        public BLLAnswer()
        {
            this.GivenAnswers = new List<BLLGivenAnswer>();
        }

        public int Id { get; set; }
        [DisplayName("Answer")]
        [Required(ErrorMessage = "An answer text is required")]
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
        [DisplayName("Is answer right?")]
        public bool IsRight { get; set; }
        public virtual BLLQuestion Question { get; set; }
        public virtual ICollection<BLLGivenAnswer> GivenAnswers { get; set; }
    }
}
