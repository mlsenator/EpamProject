using System;
using System.Collections.Generic;
using Entity.Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Interface.Entities
{
    public partial class BLLUser : IEntity
    {
        public BLLUser()
        {
            this.TestResults = new List<BLLTestResult>();
        }

        public int Id { get; set; }
        [DisplayName("Login")]
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [DisplayName("Role")]
        public int RoleId { get; set; }
        public virtual BLLRole Role { get; set; }
        public virtual ICollection<BLLTestResult> TestResults { get; set; }
    }
}
