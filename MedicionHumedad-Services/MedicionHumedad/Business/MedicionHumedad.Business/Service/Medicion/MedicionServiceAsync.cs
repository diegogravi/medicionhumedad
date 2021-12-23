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
    public class MedicionServiceAsync : GenericServiceAsync<MedicionViewModel, Medicion>, IMedicionServiceAsync
    {
        public MedicionServiceAsync(
            IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MedicionViewModel>> GetMedicionesConMasDetallesByUsuarioId(int usuarioId)
        {
            //Get all information of the Medicion
            var mediciones = from m in await _unitOfWork.GetRepositoryAsync<Medicion>().GetAll()
                             join f in await _unitOfWork.GetRepositoryAsync<Fruto>().GetAll()
                             on m.FrutoId equals f.Id
                             join s in await _unitOfWork.GetRepositoryAsync<Sensor>().GetAll()
                             on m.SensorId equals s.Id
                             join p in await _unitOfWork.GetRepositoryAsync<Plantacion>().GetAll()
                             on s.PlantacionId equals p.Id
                             join u in await _unitOfWork.GetRepositoryAsync<Usuario>().Get(x=> x.Id == usuarioId)
                             on m.UsuarioId equals u.Id
                             where m.UsuarioId == usuarioId
                             orderby m.Fecha descending
                             select new MedicionViewModel
                             {
                                 Id = m.Id,
                                 Porcentaje = m.Porcentaje,
                                 SensorId = m.SensorId,
                                 Descripcion = m.Descripcion,
                                 Fecha = m.Fecha,
                                 FrutoId = m.FrutoId,
                                 FrutoNombre = f.Nombre,
                                 PlantacionId = p.Id,
                                 PlantacionNombre = p.Nombre,
                                 UsuarioId = m.UsuarioId,
                                 UsuarioNombre = u.Nombre
                             };

            return mediciones;
        }

    }
}
