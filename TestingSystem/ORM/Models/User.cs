using System;
using System.Collections.Generic;
using Entity.Interface;

namespace ORM.Models
{
    public partial class User : IEntity
    {
        public User()
        {
            this.TestResults = new List<TestResult>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}
