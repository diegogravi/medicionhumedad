using AutoMapper;
using MedicionHumedad.Business.ViewModels;
using MedicionHumedad.Data.Models;
using MedicionHumedad.Data.UnitofWork;
using MedicionHumedad.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace MedicionHumedad.Business.Service
{
    public class FrutoServiceAsync : GenericServiceAsync<FrutoViewModel, Fruto>, IFrutoServiceAsync
    {
        public FrutoServiceAsync(
            IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

    }
}
