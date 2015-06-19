using System;
using System.Collections.Generic;
using Entity.Interface;

namespace ORM.Models
{
    public partial class Role : IEntity
    {
        public Role()
        {
            this.Users = new List<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
