namespace MedicionHumedad.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IServiceAsync<Tv, Te>
    {
        Task<IEnumerable<Tv>> GetAll();

        Task<int> Add(Tv obj);

        Task<bool> Update(Tv obj);

        Task<bool> Remove(int id);

        Task<Tv> GetById(int id);

        Task<IEnumerable<Tv>> Get(Expression<Func<Te, bool>> predicate);

        Task<Tv> GetFirstOrDefault(Expression<Func<Te, bool>> predicate);

        Task<IEnumerable<Tv>> GetPaginated(int amount, int page);

        Task<Tuple<IEnumerable<Tv>, int>> GetPaginated(int currentPage, int pageSize, string sortOn, string sortDirection);
        Task<IEnumerable<Tv>> GetFilteredPaginated(Expression<Func<Te, bool>> predicate, int amount, int page);
    }
}