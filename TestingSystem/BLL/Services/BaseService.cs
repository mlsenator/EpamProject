using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using BLL.Interface.Mappers;
using BLL.Interface.Services;
using Entity.Interface;

namespace BLL.Services
{
    public abstract class BaseService<TBll, TDal, TRepository, TMapper> : IService<TBll>
        where TBll : class, IEntity
        where TDal : class, IEntity
        where TRepository : IRepository<TDal>
        where TMapper : IMapper<TDal, TBll>, new()
    {
        public readonly TRepository repository;
        protected readonly IUnitOfWork uow;
        protected IMapper<TDal, TBll> mapper = new TMapper();

        public BaseService(TRepository repository, IUnitOfWork uow)
        {
            this.repository = repository;
            this.uow = uow;
        }

        public virtual IEnumerable<TBll> GetAll()
        {
            return repository.GetAll().Select(mapper.ToBll);
        }

        public virtual TBll GetById(int key)
        {
            TDal dto = repository.GetById(key);
            return mapper.ToBll(dto);
        }

        public virtual int Add(TBll entity)
        {
            TDal dto = mapper.ToDal(entity);
            dto.Id = repository.Create(dto);
            uow.Commit();
            return dto.Id;
        }

        public virtual void Edit(TBll entity)
        {
            TDal dto = mapper.ToDal(entity);
            repository.Update(dto);
            uow.Commit();
        }

        public virtual void Delete(TBll entity)
        {
            TDal dto = mapper.ToDal(entity);
            repository.Delete(dto);
            uow.Commit();
        }
        public virtual int GetId(TBll entity)
        {
            return repository.GetId(mapper.ToDal(entity));
        }
    }
}
