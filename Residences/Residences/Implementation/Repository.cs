using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Residences.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        // private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<T> _entities;

        //public Repository(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        public Repository(BoligContext context)
        {
            _entities = context.Set<T>();
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<T> Get()
        {
            return _entities.ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
        }

        public void Remove(T entity)
        {
            T existing = _entities.Find(entity);
            if (existing != null) _entities.Remove(existing);
        }

        public void Update(T entity)
        {
            //if (_entities.Contains(entity))
            //    _entities.Evict
            _entities.Attach(entity);
        }

        //public virtual void Create(T entity)
        //{
        //    _entities.Create();
        //}

        //public virtual void Persist(T entity)
        //{
        //    if (entity.Id == 0)
        //        Create(entity);
        //    else
        //        Update(entity);
        //}

    }
}
