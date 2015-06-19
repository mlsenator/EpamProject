using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM.Models;
using System.Data.Entity;

namespace DAL.Concrete
{
    public class RoleRepository : BaseRepository<DALRole, Role, RoleMapper>, IRoleRepository
    {
        public RoleRepository(DbContext context) : base (context) { }
    }
}
