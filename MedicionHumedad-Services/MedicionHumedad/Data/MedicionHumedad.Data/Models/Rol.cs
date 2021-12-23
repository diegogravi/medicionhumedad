using System;
using System.Collections.Generic;

namespace MedicionHumedad.Data.Models
{
    public partial class Rol : BaseModel
    {
        public Rol()
        {
            Usuario = new HashSet<Usuario>();
        }

        //public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
