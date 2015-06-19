using System;
using System.Collections.Generic;
using Entity.Interface;


namespace DAL.Interface.DTO
{
    public partial class DALUser : IEntity
    {
        public DALUser()
        {
            this.TestResults = new List<DALTestResult>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public virtual DALRole Role { get; set; }
        public virtual ICollection<DALTestResult> TestResults { get; set; }
    }
}
