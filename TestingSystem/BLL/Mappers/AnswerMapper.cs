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
    public class AnswerMapper : IMapper<DALAnswer, BLLAnswer>
    {
        public DALAnswer ToDal(BLLAnswer answer)
        {
            return answer.ToDalAnswerFull();
        }

        public BLLAnswer ToBll(DALAnswer answer)
        {
            return answer.ToBllAnswerFull();
        }
    }
}
