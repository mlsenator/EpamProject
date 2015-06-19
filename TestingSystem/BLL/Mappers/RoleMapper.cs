using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Mappers;
using DAL.Interface.DTO;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public class RoleMapper : IMapper<DALRole, BLLRole>
    {
        public DALRole ToDal(BLLRole role)
        {
            return role.ToDalRole();
        }

        public BLLRole ToBll(DALRole role)
        {
            return role.ToBllRoleFull();
        }
    }
}
