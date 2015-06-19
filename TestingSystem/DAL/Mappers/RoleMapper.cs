using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Mapper;
using DAL.Interface.DTO;
using ORM.Models;

namespace DAL.Mappers
{
    public class RoleMapper : IMapper<Role, DALRole>
    {
        public Role ToOrm(DALRole role)
        {
            return role.ToOrmRole();
        }

        public DALRole ToDal(Role role)
        {
            return role.ToDalRoleFull();
        }
    }
}
