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
    public class QuestionMapper : IMapper<Question, DALQuestion>
    {
        public Question ToOrm(DALQuestion q)
        {
            return q.ToOrmQuestionFull();
        }

        public DALQuestion ToDal(Question q)
        {
            return q.ToDalQuestionFull();
        }
    }
}
