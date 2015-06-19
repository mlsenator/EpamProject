using System;
using System.Collections.Generic;
using Entity.Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Interface.Entities
{
    public partial class BLLTest : IEntity
    {
        public BLLTest()
        {
            this.Questions = new List<BLLQuestion>();
            this.TestResults = new List<BLLTestResult>();
        }

        public int Id { get; set; }
        [DisplayName("Test")]
        [Required(ErrorMessage = "A test name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Test duration is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm\\:ss}")]
        [RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)", ErrorMessage = "Time must be between 00:00:00 to 23:59:59")]
        public System.TimeSpan Duration { get; set; }
        public virtual List<BLLQuestion> Questions { get; set; }
        public virtual ICollection<BLLTestResult> TestResults { get; set; }
    }
}
