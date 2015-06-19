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
    public class GivenAnswerMapper : IMapper<DALGivenAnswer, BLLGivenAnswer>
    {
        public DALGivenAnswer ToDal(BLLGivenAnswer ga)
        {
            return ga.ToDalGivenAnswerFull();
        }

        public BLLGivenAnswer ToBll(DALGivenAnswer ga)
        {
            return ga.ToBllGivenAnswerFull();
        }
    }
}
