using System;
using System.Collections.Generic;

namespace MedicionHumedad.Data.Models
{
    public partial class Usuario : BaseModel
    {
        public Usuario()
        {
            Medicion = new HashSet<Medicion>();
        }

        //public int Id { get; set; }
        public string Guid { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Activo { get; set; }
        public string Password { get; set; }
        public int PlantacionId { get; set; }
        public int RolId { get; set; }

        public virtual Plantacion Plantacion { get; set; }
        public virtual Rol Rol { get; set; }
        public virtual ICollection<Medicion> Medicion { get; set; }
    }
}
