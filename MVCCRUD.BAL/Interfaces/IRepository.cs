using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVCCRUD.BAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {

        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Edit(TEntity entity);

        //read side (could be in separate Readonly Generic Repository)
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate);

        //separate method SaveChanges can be helpful when using this pattern with UnitOfWork
        void SaveChanges();
    }
}
