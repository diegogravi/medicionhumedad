namespace MedicionHumedad.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using MedicionHumedad.Models;
    using MedicionHumedad.Service;
    using MedicionHumedad.Data.UnitofWork;
    using MedicionHumedad.Data.Models;

    public abstract class GenericServiceAsync<Tv, Te> : IServiceAsync<Tv, Te>
        where Tv : BaseViewModel
        where Te : BaseModel
    {
        protected IMapper _mapper;
        protected IUnitOfWork _unitOfWork;

        public GenericServiceAsync(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<IEnumerable<Tv>> GetAll()
        {
            var entities = await _unitOfWork.GetRepositoryAsync<Te>()
                .GetAll();
            return _mapper.Map<IEnumerable<Tv>>(source: entities);
        }

        public virtual async Task<Tv> GetById(int id)
        {
            var entity = await _unitOfWork.GetRepositoryAsync<Te>()
                .GetById(predicate: x => x.Id == id);
            return _mapper.Map<Tv>(source: entity);
        }

        public virtual async Task<int> Add(Tv view)
        {
            var entity = _mapper.Map<Te>(source: view);
            await _unitOfWork.GetRepositoryAsync<Te>().Insert(entity);
            await _unitOfWork.SaveAsync();
            return entity.Id;
        }

        public async Task<bool> Update(Tv view)
        {
            await _unitOfWork.GetRepositoryAsync<Te>().Update(view.Id, _mapper.Map<Te>(source: view));
            return await _unitOfWork.SaveAsync();
        }

        public virtual async Task<bool> Remove(int id)
        {
            await _unitOfWork.GetRepositoryAsync<Te>().Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public virtual async Task<IEnumerable<Tv>> Get(Expression<Func<Te, bool>> predicate)
        {
            var items = await _unitOfWork.GetRepositoryAsync<Te>()
                .Get(predicate: predicate);
            return _mapper.Map<IEnumerable<Tv>>(source: items);
        }

        public virtual async Task<Tv> GetFirstOrDefault(Expression<Func<Te, bool>> predicate)
        {
            var entities = await _unitOfWork.GetRepositoryAsync<Te>()
                .GetFirstOrDefault<Te>(predicate: predicate);
            return _mapper.Map<Tv>(source: entities);
        }

        public virtual async Task<IEnumerable<Tv>> GetPaginated(int amount, int page)
        {
            var skip = amount * page;
            var entities = (await _unitOfWork.GetRepositoryAsync<Te>()
                .GetAll()).Skip(skip).Take(amount).ToList();
            return _mapper.Map<IEnumerable<Tv>>(source: entities);
        }

        public virtual async Task<Tuple<IEnumerable<Tv>, int>> GetPaginated(int currentPage, int pageSize, string sortOn, string sortDirection)
        {
            //var entities = (await _unitOfWork.GetRepositoryAsync<Te>()
            //    .GetAll()).Skip(skip).Take(amount).ToList();

            var tuple = await _unitOfWork.GetRepositoryAsync<Te>().GetAll(currentPage, pageSize, sortOn, sortDirection);

            return new Tuple<IEnumerable<Tv>, int>(_mapper.Map<IEnumerable<Tv>>(source: tuple.Item1), tuple.Item2);
        }

        public virtual async Task<Tuple<IEnumerable<Tv>, int>> GetTablePaginated(Expression<Func<Te, bool>> predicate, int currentPage, int pageSize, string sortOn, string sortDirection)
        {
            //var entities = (await _unitOfWork.GetRepositoryAsync<Te>()
            //    .GetAll()).Skip(skip).Take(amount).ToList();

            var tuple = await _unitOfWork.GetRepositoryAsync<Te>().GetAll(currentPage, pageSize, sortOn, sortDirection);

            return new Tuple<IEnumerable<Tv>, int>(_mapper.Map<IEnumerable<Tv>>(source: tuple.Item1), tuple.Item2);
        }



        public virtual async Task<IEnumerable<Tv>> GetFilteredPaginated(Expression<Func<Te, bool>> predicate, int amount, int page)
        {
            var skip = amount * page;
            var entities = (await _unitOfWork.GetRepositoryAsync<Te>()
                .Get(predicate: predicate)).Skip(skip).Take(amount).ToList();
            return _mapper.Map<IEnumerable<Tv>>(source: entities);

        }

    }
}