namespace MedicionHumedad.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using MedicionHumedad.Data.UnitofWork;
    using MedicionHumedad.Data.Extensions;

    /// <summary>
    /// General repository class async
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        public RepositoryAsync(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<T>> GetAll(
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await _unitOfWork.Context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<Tuple<IEnumerable<T>, int>> GetAll(int currentPage, int pageSize, string sortOn, string sortDirection)
        {
            int count = await _unitOfWork.Context.Set<T>().CountAsync();
            IQueryable<T> source = _unitOfWork.Context.Set<T>().AsTracking().AsQueryable();

            if (!string.IsNullOrEmpty(sortOn))
            {
                if (sortDirection.ToUpper() == "ASC")
                {
                    source = source.OrderBy(sortOn);
                }
                else
                {
                    source = source.OrderByDescending(sortOn);
                }
            }

            source = source.Skip((currentPage - 1) * pageSize).Take(pageSize);

            return new Tuple<IEnumerable<T>, int>(source.ToList(), count);
        }

        public async Task<Tuple<IEnumerable<T>, int>> GetAll(IEnumerable<T> list, int currentPage, int pageSize, string sortOn, string sortDirection)
        {
            int count = await list.AsQueryable().CountAsync();
            IQueryable<T> source = list.AsQueryable();

            if (!string.IsNullOrEmpty(sortOn))
            {
                if (sortDirection.ToUpper() == "ASC")
                {
                    source = source.OrderBy(sortOn);
                }
                else
                {
                    source = source.OrderByDescending(sortOn);
                }
            }

            source = source.Skip((currentPage - 1) * pageSize).Take(pageSize);

            return new Tuple<IEnumerable<T>, int>(source.ToList(), count);
        }


        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await _unitOfWork.Context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await _unitOfWork.Context.Set<T>().AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task Insert(T entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Context.Set<T>().AddAsync(entity);
            }
        }

        public async Task Update(object id, T entity)
        {
            if (entity != null)
            {
                T entitytoUpdate = await _unitOfWork.Context.Set<T>().FindAsync(id);
                if (entitytoUpdate != null)
                {
                    _unitOfWork.Context.Entry(entitytoUpdate).CurrentValues.SetValues(entity);
                }
            }
        }

        public async Task Update(T entity)
        {
            if (entity != null)
            {
                _unitOfWork.Context.Entry(entity).CurrentValues.SetValues(entity);
            }
        }

        public async Task Delete(object id)
        {
            T entity = await _unitOfWork.Context.Set<T>().FindAsync(id);
            Delete(entity);
        }

        public void Delete(T entity)
        {
            if (entity != null)
            {
                _unitOfWork.Context.Set<T>().Remove(entity);
            }
        }

        public async Task<T> GetFirstOrDefault<Te>(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await _unitOfWork.Context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<Tuple<IEnumerable<T>, int>> GetAllOrderByDescending(IEnumerable<T> list, int pageSize, string sortOn)
        {
            int count = await list.AsQueryable().CountAsync();
            IQueryable<T> source = list.AsQueryable();

            source = source.OrderByDescending(sortOn);

            source = source.Take(pageSize);

            return new Tuple<IEnumerable<T>, int>(source.ToList(), count);
        }
        
    }
}