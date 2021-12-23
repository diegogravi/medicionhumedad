using System;
using System.Collections.Generic;

namespace MedicionHumedad.Data.Models
{
    public partial class Plantacion : BaseModel
    {
        public Plantacion()
        {
            Sensor = new HashSet<Sensor>();
            Usuario = new HashSet<Usuario>();
        }

        //public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Sensor> Sensor { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
