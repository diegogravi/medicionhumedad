

namespace MedicionHumedad.Services.Service.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using AutoMapper;
    using MedicionHumedad.Data.Models;
    using MedicionHumedad.Data.UnitofWork;
    using MedicionHumedad.Models;

    public abstract class GenericService<Tv, Te> : IService<Tv, Te>
        where Tv : BaseViewModel
        where Te : BaseModel
    {
        private readonly IMapper _mapper;
        protected IUnitOfWork _unitOfWork;

        public GenericService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public virtual IEnumerable<Tv> GetAll()
        {
            var entities = _unitOfWork.GetRepository<Te>().GetAll();
            return _mapper.Map<IEnumerable<Tv>>(source: entities);
        }

        public virtual Tv GetById(int id)
        {
            var entity = _unitOfWork.GetRepository<Te>().GetById(predicate: x => x.Id == id);
            return _mapper.Map<Tv>(source: entity);
        }

        public virtual int Add(Tv view)
        {
            var entity = _mapper.Map<Te>(source: view);
            _unitOfWork.GetRepository<Te>().Insert(entity);
            _unitOfWork.Save();
            return entity.Id;
        }

        public virtual bool Update(Tv view)
        {
            _unitOfWork.GetRepository<Te>().Update(view.Id, _mapper.Map<Te>(source: view));
            return _unitOfWork.Save();
        }

        public virtual bool Remove(int id)
        {
            _unitOfWork.GetRepository<Te>().Delete(id);
            return _unitOfWork.Save();
        }

        public virtual Tv GetFirstOrDefault(Expression<Func<Te, bool>> predicate)
        {
            var entities = _unitOfWork.GetRepository<Te>()
                .GetFirstOrDefault(predicate: predicate);
            return _mapper.Map<Tv>(source: entities);
        }

        // GET with filters
        public virtual IEnumerable<Tv> Get(Expression<Func<Te, bool>> predicate)
        {
            var entities = _unitOfWork.GetRepository<Te>()
                .Get(predicate: predicate).ToList();
            return _mapper.Map<IEnumerable<Tv>>(source: entities);
        }

        // GET with pagination
        public virtual IEnumerable<Tv> Get(int amount, int page)
        {
            var skip = amount * page;
            var entities = _unitOfWork.GetRepository<Te>()
                .GetAll().Skip(skip).Take(amount).ToList();
            return _mapper.Map<IEnumerable<Tv>>(source: entities);
        }

        // GET with filters and pagination
        public virtual IEnumerable<Tv> Get(Expression<Func<Te, bool>> predicate, int amount, int page)
        {
            var skip = amount * page;
            var entities = _unitOfWork.GetRepository<Te>()
                .Get(predicate: predicate).Skip(skip).Take(amount).ToList();
            return _mapper.Map<IEnumerable<Tv>>(source: entities);
        }
    }
}