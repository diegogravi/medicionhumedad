using AutoMapper;
using MedicionHumedad.Business.ViewModels;
using MedicionHumedad.Data.Models;
using MedicionHumedad.Data.UnitofWork;
using MedicionHumedad.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicionHumedad.Business.Service
{
    public class SensorServiceAsync : GenericServiceAsync<SensorViewModel, Sensor>, ISensorServiceAsync
    {
        public SensorServiceAsync(
            IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<SensorViewModel>> GetSensoresConMasDetalles()
        {
            //Get all information of the Medicion
            var mediciones = from s in await _unitOfWork.GetRepositoryAsync<Sensor>().GetAll()
                             join p in await _unitOfWork.GetRepositoryAsync<Plantacion>().GetAll()
                             on s.PlantacionId equals p.Id                             
                             select new SensorViewModel
                             {
                                 Id = s.Id,
                                 Activo = s.Activo,
                                 FechaCreacion = s.FechaCreacion,
                                 PlantacionId = s.PlantacionId,
                                 PlantacionNombre = p.Nombre
                             };

            return mediciones;
        }
    }
}
