using DAL.Interface.Repository;
using DAL.Interface.DTO;
using BLL.Mappers;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace BLL.Services
{
    public class TestService : BaseService<BLLTest, DALTest, ITestRepository, TestMapper>, ITestService
    {
        public TestService(ITestRepository repository, IUnitOfWork uow) : base(repository, uow) 
        {

        }
    }
}
