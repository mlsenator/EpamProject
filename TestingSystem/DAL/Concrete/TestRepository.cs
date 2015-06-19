using DAL.Interface.Repository;
using ORM.Models;
using DAL.Interface.DTO;
using System.Data.Entity;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class TestRepository  : BaseRepository<DALTest, Test, TestMapper>, ITestRepository
    {
        public TestRepository(DbContext context) : base(context) 
        {

        }
    }
}
