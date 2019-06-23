using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ListaProizvoda.Shared
{
    public abstract class DataRepository<C, T> : IDataRepository<T>
        where T : class where C : DbContext, new()
    {
        private C context = new C();

        public virtual C Context { get => context; set => context = value; }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = Context.Set<T>();
            return query;
        }

        public virtual void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public virtual void Edit(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }

}