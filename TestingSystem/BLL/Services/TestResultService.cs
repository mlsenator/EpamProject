using DAL.Interface.Repository;
using DAL.Interface.DTO;
using BLL.Mappers;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace BLL.Services
{
    public class TestResultService : BaseService<BLLTestResult, DALTestResult, ITestResultRepository, TestResultMapper>, ITestResultService
    {
        public TestResultService(ITestResultRepository repository, IUnitOfWork uow) : base(repository, uow) { }
    }
}
