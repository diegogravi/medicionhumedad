using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeHoteling.ViewModel
{
    public class CheckinViewModel
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public int StaffId { get; set; }
        public DateTime FechaCheckin { get; set; }
        public int EdificioId { get; set; }
        public string EdificioNombre { get; set; }
        public string EspacioDescripcion { get; set; }
    }
}