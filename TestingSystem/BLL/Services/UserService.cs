using DAL.Interface.Repository;
using DAL.Interface.DTO;
using BLL.Mappers;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace BLL.Services
{
    public class UserService : BaseService<BLLUser, DALUser, IUserRepository, UserMapper>, IUserService
    {
        public UserService(IUserRepository repository, IUnitOfWork uow) : base(repository, uow) { }
    }
}
