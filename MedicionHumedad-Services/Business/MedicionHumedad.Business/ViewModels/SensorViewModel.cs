using MedicionHumedad.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicionHumedad.Business.ViewModels
{
    public class SensorViewModel : BaseViewModel
    {
        public DateTimeOffset FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public int? PlantacionId { get; set; }


    }
}
