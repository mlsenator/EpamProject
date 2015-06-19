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
    public class UserMapper : IMapper<User, DALUser>
    {
        public User ToOrm(DALUser user)
        {
            return user.ToOrmUser();
        }

        public DALUser ToDal(User user)
        {
            return user.ToDalUserFull();
        }
    }
}
