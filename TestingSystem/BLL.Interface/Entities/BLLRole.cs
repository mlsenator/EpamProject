using System;
using System.Collections.Generic;
using Entity.Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Interface.Entities
{
    public partial class BLLRole : IEntity
    {
        public BLLRole()
        {
            this.Users = new List<BLLUser>();
        }

        public int Id { get; set; }
        [DisplayName("Role")]
        [Required(ErrorMessage = "A role name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<BLLUser> Users { get; set; }
    }
}
