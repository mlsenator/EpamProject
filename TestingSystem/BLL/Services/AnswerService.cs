using DAL.Interface.Repository;
using DAL.Interface.DTO;
using BLL.Mappers;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace BLL.Services
{
    public class AnswerService : BaseService<BLLAnswer, DALAnswer, IAnswerRepository, AnswerMapper>, IAnswerService
    {
        public AnswerService(IAnswerRepository repository, IUnitOfWork uow) : base(repository, uow) { }
    }
}
