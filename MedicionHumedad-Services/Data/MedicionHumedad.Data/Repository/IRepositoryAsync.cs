namespace MedicionHumedad.Data.Repository
{
    using Microsoft.EntityFrameworkCore.Query;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepositoryAsync<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<T> GetById(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<Tuple<IEnumerable<T>, int>> GetAll(int currentPage, int pageSize, string sortOn, string sortDirection);

        //Task<Tuple<IEnumerable<T>, int>> GetPaginatedEntity(IEnumerable<int> collection, int currentPage, int pageSize, string sortOn, string sortDirection);

        Task Insert(T entity);

        void Delete(T entity);

        Task Delete(object id);

        Task Update(object id, T entity);
        Task Update(T entity);

        Task<T> GetFirstOrDefault<Te>(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<Tuple<IEnumerable<T>, int>> GetAll(IEnumerable<T> list, int currentPage, int pageSize, string sortOn, string sortDirection);
    }
}
