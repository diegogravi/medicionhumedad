using AutoMapper;
using MedicionHumedad.Business.ViewModels;
using MedicionHumedad.Data.Models;
using MedicionHumedad.Data.UnitofWork;
using MedicionHumedad.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicionHumedad.Business.Service
{
    public class UsuarioServiceAsync : GenericServiceAsync<UsuarioViewModel, Usuario>, IUsuarioServiceAsync
    {
        public UsuarioServiceAsync(
            IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}
