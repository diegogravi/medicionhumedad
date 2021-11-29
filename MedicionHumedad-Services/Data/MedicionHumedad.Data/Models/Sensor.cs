using System;
using System.Collections.Generic;

namespace MedicionHumedad.Data.Models
{
    public partial class Sensor : BaseModel
    {
        //public int Id { get; set; }
        public DateTimeOffset FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public int? PlantacionId { get; set; }

        public virtual Plantacion Plantacion { get; set; }
    }
}
