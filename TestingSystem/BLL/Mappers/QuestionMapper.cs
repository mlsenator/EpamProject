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
    public class QuestionMapper : IMapper<DALQuestion, BLLQuestion>
    {
        public DALQuestion ToDal(BLLQuestion q)
        {
            return q.ToDalQuestionFull();
        }

        public BLLQuestion ToBll(DALQuestion q)
        {
            return q.ToBllQuestionFull();
        }
    }
}
