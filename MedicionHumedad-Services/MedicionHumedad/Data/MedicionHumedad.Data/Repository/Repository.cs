namespace MedicionHumedad.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using MedicionHumedad.Data.UnitofWork;

    /// <summary>
    /// General repository class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.Context.Set<T>().AsNoTracking();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().AsNoTracking().Where(predicate).AsEnumerable<T>();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().AsNoTracking().Where(predicate).FirstOrDefault();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().AsNoTracking().Where(predicate).FirstOrDefault();
        }

        public void Insert(T entity)
        {
            if (entity != null)
            {
                _unitOfWork.Context.Set<T>().Add(entity);
            }
        }

        public void Update(object id, T entity)
        {
            if (entity != null)
            {
                T entitytoUpdate = _unitOfWork.Context.Set<T>().Find(id);
                if (entitytoUpdate != null)
                {
                    _unitOfWork.Context.Entry(entitytoUpdate).CurrentValues.SetValues(entity);
                }
            }
        }

        public void Update(T entity)
        {
            if (entity != null)
            {
                _unitOfWork.Context.Entry(entity).CurrentValues.SetValues(entity);
            }
        }


        public void Delete(object id)
        {
            T entity = _unitOfWork.Context.Set<T>().Find(id);
            Delete(entity);
        }

        public void Delete(T entity)
        {
            if (entity != null)
            {
                _unitOfWork.Context.Set<T>().Remove(entity);
            }
        }

        public IEnumerable<T> Get(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return include(_unitOfWork.Context.Set<T>().AsNoTracking().Where(predicate)).AsEnumerable();
        }

        public IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return include(_unitOfWork.Context.Set<T>().AsNoTracking()).AsEnumerable();
        }

        public T GetFirstOrDefault(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return include(_unitOfWork.Context.Set<T>().AsNoTracking().Where(predicate)).FirstOrDefault();
        }

        public T GetById(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return include(_unitOfWork.Context.Set<T>().AsNoTracking().Where(predicate)).FirstOrDefault();
        }
    }
}
