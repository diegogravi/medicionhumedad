﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeHoteling.ViewModel
{
    public class StaffViewModel
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Activo { get; set; }
        public bool EsPersonalAuxiliar { get; set; }
        public string Password { get; set; }
    }
}