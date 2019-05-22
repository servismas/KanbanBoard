using DataAccessLayer.cs.Interfases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.cs.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;
        private readonly DbSet<T> set;
        public Repository(DbContext _context)
        {
            context = _context;
            set = context.Set<T>();
        }
        public void Add(T entity)
        {
            set.Add(entity);
            context.SaveChanges();
        }

        public void Edit(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public T Find(int id)
        {
            return set.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return set.AsNoTracking().AsEnumerable();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> pred)
        {
            return set.AsNoTracking().Where(pred).AsEnumerable();
        }

        public void Remove(T entity)
        {
            set.Remove(entity);
            context.SaveChanges();
        }
    }
}
