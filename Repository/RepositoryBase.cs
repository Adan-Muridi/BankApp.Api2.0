using Contracts;
using Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected BankDbContext bankDbContext;

        public RepositoryBase(BankDbContext BankDbContext)
        {
            this.bankDbContext = BankDbContext;
        }
        public void Create(T entity) => bankDbContext.Set<T>().Add(entity);

        public void Delete(T entity) => bankDbContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
                 !trackChanges ?
                 bankDbContext.Set<T>()
                 .AsNoTracking() :
                 bankDbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
                 bool trackChanges) =>
                 !trackChanges ?
                 bankDbContext.Set<T>()
                 .Where(expression)
                 .AsNoTracking() :
                 bankDbContext.Set<T>()
                 .Where(expression);

        public void Update(T entity) => bankDbContext.Set<T>().Update(entity);
    }
}
