using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.cs.Interfases
{
    public interface IRepository<T> where T:class
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> pred);
        IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetAllInclude(params Expression<Func<T, object>>[] includeProperties);
        T Find(int id);
        void Remove(T entity);
        void Edit(T entity);
    }
}
