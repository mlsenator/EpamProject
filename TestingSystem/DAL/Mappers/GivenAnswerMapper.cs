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
    public class GivenAnswerMapper : IMapper<GivenAnswer, DALGivenAnswer>
    {
        public GivenAnswer ToOrm(DALGivenAnswer ga)
        {
            return ga.ToOrmGivenAnswerFull();
        }

        public DALGivenAnswer ToDal(GivenAnswer ga)
        {
            return ga.ToDalGivenAnswerFull();
        }
    }
}
