using System;
using System.Collections.Generic;

namespace MedicionHumedad.Data.Models
{
    public partial class Medicion : BaseModel
    {
        //public int Id { get; set; }
        public decimal Porcentaje { get; set; }
        public DateTimeOffset Fecha { get; set; }
        public string Descripcion { get; set; }
        public int FrutoId { get; set; }
        public int UsuarioId { get; set; }
        public int? SensorId { get; set; }

        public virtual Fruto Fruto { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
