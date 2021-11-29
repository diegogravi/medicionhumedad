using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicionHumedad.ViewModel
{
    public class CheckinViewModel
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaCheckin { get; set; }
        public int EdificioId { get; set; }
        public string EdificioNombre { get; set; }
        public string EspacioDescripcion { get; set; }
    }
}