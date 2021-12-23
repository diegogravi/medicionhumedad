using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicionHumedad.ViewModel
{
    public class SensorViewModel : BaseViewModel
    {
        public DateTimeOffset FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public int? PlantacionId { get; set; }
        public string PlantacionNombre { get; set; }
    }
}