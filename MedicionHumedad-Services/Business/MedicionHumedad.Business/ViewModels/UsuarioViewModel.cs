using MedicionHumedad.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicionHumedad.Business.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {
        public string Guid { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Activo { get; set; }
        public string Password { get; set; }
        public int PlantacionId { get; set; }
        public int RolId { get; set; }
    }
}
