using System;
using System.Collections.Generic;
using Entity.Interface;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Interface.Entities
{
    public partial class BLLQuestion : IEntity
    {
        public BLLQuestion()
        {
            this.Answers = new List<BLLAnswer>();
        }

        public int Id { get; set; }
        [DisplayName("Question")]
        [Required(ErrorMessage = "A question text is required")]
        public string QuestionText { get; set; }
        public int TestId { get; set; }
        public virtual List<BLLAnswer> Answers { get; set; }
        public virtual BLLTest Test { get; set; }
        public int NumOfRightAnswers
        {
            get
            {
                return Answers.Where(a => a.IsRight == true).Count();
            }
        }
    }
}
