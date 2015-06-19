using DAL.Interface.Repository;
using ORM.Models;
using DAL.Interface.DTO;
using System.Data.Entity;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class GivenAnswerRepository : BaseRepository<DALGivenAnswer, GivenAnswer, GivenAnswerMapper>, IGivenAnswerRepository
    {
        public GivenAnswerRepository(DbContext context) : base(context) { }
    }
}
