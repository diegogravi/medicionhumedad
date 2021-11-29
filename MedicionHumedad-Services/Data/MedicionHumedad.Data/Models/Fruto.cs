using System;
using System.Collections.Generic;

namespace MedicionHumedad.Data.Models
{
    public partial class Fruto : BaseModel
    {
        public Fruto()
        {
            Medicion = new HashSet<Medicion>();
        }

        //public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Medicion> Medicion { get; set; }
    }
}
