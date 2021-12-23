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
    public class UsuarioServiceAsync : GenericServiceAsync<UsuarioViewModel, Usuario>, IUsuarioServiceAsync
    {
        public UsuarioServiceAsync(
            IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<UsuarioViewModel>> GetAllUsuarios()
        {
            //Get all information of the Medicion
            var mediciones = from u in await _unitOfWork.GetRepositoryAsync<Usuario>().GetAll()
                             join r in await _unitOfWork.GetRepositoryAsync<Rol>().GetAll()                             
                             on u.RolId equals r.Id
                             select new UsuarioViewModel
                             {
                                 Activo = u.Activo,
                                 Apellido = u.Apellido,
                                 Guid = u.Guid,
                                 Id = u.Id,
                                 Nombre = u.Nombre,
                                 Password = u.Password,
                                 PlantacionId = u.PlantacionId,
                                 RolId = u.RolId,
                                 RolNombre = r.Nombre
                             };

            return mediciones;
        }
    }
}
