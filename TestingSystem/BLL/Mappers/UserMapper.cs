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
    public class UserMapper : IMapper<DALUser, BLLUser>
    {
        public DALUser ToDal(BLLUser user)
        {
            return user.ToDalUser();
        }

        public BLLUser ToBll(DALUser user)
        {
            return user.ToBllUserFull();
        }
    }
}
