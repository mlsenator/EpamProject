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
    public class AnswerMapper : IMapper<Answer, DALAnswer>
    {
        public Answer ToOrm(DALAnswer answer)
        {
            return answer.ToOrmAnswerFull();
        }

        public DALAnswer ToDal(Answer answer)
        {
            return answer.ToDalAnswerFull();
        }
    }
}
