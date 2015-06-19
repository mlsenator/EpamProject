using DAL.Interface.Repository;
using ORM.Models;
using DAL.Interface.DTO;
using System.Data.Entity;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class AnswerRepository : BaseRepository<DALAnswer, Answer, AnswerMapper>, IAnswerRepository
    {
        public AnswerRepository(DbContext context) : base(context) { }
    }
}
