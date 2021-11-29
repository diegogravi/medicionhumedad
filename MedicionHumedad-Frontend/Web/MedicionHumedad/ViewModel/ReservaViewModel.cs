using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicionHumedad.ViewModel
{
    public class ReservaViewModel
    {
        public int Id { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int EspacioId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime CreadaEn { get; set; }
        public string EspacioDescripcion { get; set; }
        public bool Active { get; set; }
    }
}