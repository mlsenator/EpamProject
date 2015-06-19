using System;
using System.Collections.Generic;
using Entity.Interface;

namespace DAL.Interface.DTO
{
    public partial class DALRole : IEntity
    {
        public DALRole()
        {
            this.Users = new List<DALUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<DALUser> Users { get; set; }
    }
}
