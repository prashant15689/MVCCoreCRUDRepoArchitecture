using Microsoft.EntityFrameworkCore;
using MVCCRUD.BAL.Interfaces;
using MVCCRUD.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCRUD.BAL.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly CompanyDbContext Context;
        public BaseRepository(CompanyDbContext context) => Context = context;

        public void Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void Delete(int id)
        {
            var entityToDelete = Context.Set<TEntity>().Find(id);
            if (entityToDelete != null)
            {
                Context.Set<TEntity>().Remove(entityToDelete);
            }
        }

        public void Edit(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void SaveChanges() => Context.SaveChanges();
    }
}
