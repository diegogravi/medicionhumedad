using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicionHumedad.ViewModel
{
    public class UsuarioViewModel: BaseViewModel
    {
        public string Guid { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Activo { get; set; }
        public string Password { get; set; }
        public int PlantacionId { get; set; }
        public int RolId { get; set; }
        public bool EsAdminOIrrigador
        {
            get
            {
                if (this.RolId == 2 || this.RolId == 3)
                {
                    return true;
                }
                return false;

            }
            set
            {
                if (value)
                {
                    this.RolId = 3;
                }
                else
                {
                    this.RolId = 1;
                }
            }
        }
    }
}