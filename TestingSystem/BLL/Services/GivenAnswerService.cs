using DAL.Interface.Repository;
using DAL.Interface.DTO;
using BLL.Mappers;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace BLL.Services
{
    public class GivenAnswerService : BaseService<BLLGivenAnswer, DALGivenAnswer, IGivenAnswerRepository, GivenAnswerMapper>, IGivenAnswerService
    {
        public GivenAnswerService(IGivenAnswerRepository repository, IUnitOfWork uow) : base(repository, uow) { }
    }
}
