using DAL.Interface.Repository;
using ORM.Models;
using DAL.Interface.DTO;
using System.Data.Entity;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class UserRepository : BaseRepository<DALUser, User, UserMapper>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }
    }
}
