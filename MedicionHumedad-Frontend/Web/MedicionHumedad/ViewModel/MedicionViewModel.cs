using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicionHumedad.ViewModel
{
    public class MedicionViewModel : BaseViewModel
    {
        public decimal Porcentaje { get; set; }
        public DateTimeOffset Fecha { get; set; }
        public string Descripcion { get; set; }
        public int FrutoId { get; set; }
        public int UsuarioId { get; set; }
        public int? SensorId { get; set; }

        public string FrutoNombre { get; set; }
        public string UsuarioNombre { get; set; }
        public string PlantacionNombre { get; set; }
        public int PlantacionId { get; set; }
    }
}