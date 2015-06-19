using DAL.Interface.Repository;
using DAL.Interface.DTO;
using BLL.Mappers;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace BLL.Services
{
    public class QuestionService : BaseService<BLLQuestion, DALQuestion, IQuestionRepository, QuestionMapper>, IQuestionService
    {
        public QuestionService(IQuestionRepository repository, IUnitOfWork uow) : base(repository, uow) { }
    }
}
