using DAL.Interface.Repository;
using DAL.Interface.DTO;
using BLL.Mappers;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace BLL.Services
{
    public class RoleService : BaseService<BLLRole, DALRole, IRoleRepository, RoleMapper>, IRoleService
    {
        public RoleService(IRoleRepository repository, IUnitOfWork uow) : base(repository, uow) { }
    }
}
