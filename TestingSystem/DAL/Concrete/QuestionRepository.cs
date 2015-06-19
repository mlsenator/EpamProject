using DAL.Interface.Repository;
using ORM.Models;
using DAL.Interface.DTO;
using System.Data.Entity;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class QuestionRepository : BaseRepository<DALQuestion, Question, QuestionMapper>, IQuestionRepository
    {
        public QuestionRepository(DbContext context) : base(context) { }
    }
}
