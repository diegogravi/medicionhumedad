namespace MedicionHumedad.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IService<Tv, Te>
    {
        IEnumerable<Tv> GetAll();

        int Add(Tv obj);

        bool Update(Tv obj);

        bool Remove(int id);

        Tv GetById(int id);

        Tv GetFirstOrDefault(Expression<Func<Te, bool>> predicate);

        IEnumerable<Tv> Get(Expression<Func<Te, bool>> predicate);

        IEnumerable<Tv> Get(int amount, int page);

        IEnumerable<Tv> Get(Expression<Func<Te, bool>> predicate, int amount, int page);
    }
}