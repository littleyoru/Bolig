using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Residences.Implementation
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void Update(T entity);
        //void Persist(T entity);
        //void Persist(List<T> entities);
        // void RemoveRange(IEnumerable<T> entities);
    }
}
