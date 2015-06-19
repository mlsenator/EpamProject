using DAL.Interface.Repository;
using ORM.Models;
using DAL.Interface.DTO;
using System.Data.Entity;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class TestResultRepository : BaseRepository<DALTestResult, TestResult, TestResultMapper>, ITestResultRepository
    {
        public TestResultRepository(DbContext context) : base(context) { }
    }
}
