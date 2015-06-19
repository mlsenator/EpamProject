using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IService<TEntity>  where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int key);
        int Add(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
        int GetId(TEntity entity);
    }
}
