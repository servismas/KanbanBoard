using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.cs.Interfases
{
    public interface IRepository<T> where T:class
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
        T Find(int id);
        void Remove(T entity);
        void Edit(T entity);
    }
}
