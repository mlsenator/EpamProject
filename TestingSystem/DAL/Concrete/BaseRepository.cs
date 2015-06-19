using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DAL.Interface.Repository;
using DAL.Interface.Mapper;
using Entity.Interface;

namespace DAL.Concrete
{
    public abstract class BaseRepository<TDal, TOrm, TMapper> : IRepository<TDal>
        where TDal : class, IEntity
        where TOrm : class, IEntity
        where TMapper : IMapper<TOrm, TDal>, new()
    {
        private readonly DbContext context;
        protected IMapper<TOrm, TDal> mapper = new TMapper();
        public BaseRepository(DbContext context)
        {
            this.context = context;
        }

        public virtual IEnumerable<TDal> GetAll()
        {
            return context.Set<TOrm>().Select(mapper.ToDal);
        }
        public virtual TDal GetById(int key)
        {
            TOrm model = context.Set<TOrm>().FirstOrDefault(e => e.Id == key);
            return mapper.ToDal(model);
        }
        public virtual IEnumerable<TDal> GetByPredicate(Expression<Func<TDal, bool>>[] f)
        {
            IQueryable<TOrm> temp = context.Set<TOrm>().AsQueryable();
            IQueryable<TDal> tempDal = temp.Select(mapper.ToDal).AsQueryable();
            tempDal = f.Aggregate(tempDal, (current, predicate) => current.Where(predicate));
            return tempDal.AsEnumerable();
        }
        public virtual int Create(TDal entity)
        {
            TOrm modelEntity = mapper.ToOrm(entity);
            DbEntityEntry<TOrm> dbEntity = context.Entry<TOrm>(modelEntity);
            context.Set<TOrm>().Add(dbEntity.Entity);
            context.SaveChanges();
            return dbEntity.Entity.Id;
        }
        public virtual void Delete(TDal entity)
        {
            TOrm modelEntity = mapper.ToOrm(entity);
            DbEntityEntry<TOrm> dbEntity = context.Entry<TOrm>(context.Set<TOrm>().Find(entity.Id));
            //dbEntity.State = EntityState.Deleted;
            context.Set<TOrm>().Remove(dbEntity.Entity);
        }
        public virtual void Update(TDal entity)
        {
            TOrm modelEntity = mapper.ToOrm(entity);
            var x = context.Set<TOrm>().Find(modelEntity.Id);
            context.Entry(x).CurrentValues.SetValues(modelEntity);
        }
        public virtual int GetId(TDal entity)
        {
            return 0;
        }
    }
}
