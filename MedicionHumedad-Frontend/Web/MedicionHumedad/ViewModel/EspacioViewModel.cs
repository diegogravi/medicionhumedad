using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicionHumedad.ViewModel
{
    public class EspacioViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int PisoId { get; set; }
    }
}