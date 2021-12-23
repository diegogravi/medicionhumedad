using MedicionHumedad.Business.ViewModels;
using MedicionHumedad.Service;
using System;
using System.Collections.Generic;
using System.Text;
using MedicionHumedad.Data.Models;
using System.Threading.Tasks;

namespace MedicionHumedad.Business.Service
{
    public interface IUsuarioServiceAsync : IServiceAsync<UsuarioViewModel, Usuario>
    {
        Task<IEnumerable<UsuarioViewModel>> GetAllUsuarios();
    }
}
