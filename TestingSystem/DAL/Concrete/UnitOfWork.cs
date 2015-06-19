using System;
using System.Data.Entity;
using DAL.Interface.Repository;
using ORM;

namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; private set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            if (Context != null)
            {
                Context.SaveChanges();
            }
        }

        //public void Dispose()
        //{
        //    Context.Dispose();
        //}
    }
}
