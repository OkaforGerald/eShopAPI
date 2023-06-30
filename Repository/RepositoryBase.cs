using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext Context;

        public RepositoryBase(RepositoryContext context)
        {

            Context = context;

        }
        public void Create(T entity) => Context.Set<T>().Add(entity);

        public void Delete(T entity) => Context.Set<T>().Remove(entity);

        public void Update(T entity) => Context.Set<T>().Update(entity);

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? 
                Context.Set<T>().AsNoTracking() : 
                Context.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges)
        {
            return !trackChanges ?
                Context.Set<T>().Where(condition).AsNoTracking() :
                Context.Set<T>().Where(condition);
        }
    }
}
