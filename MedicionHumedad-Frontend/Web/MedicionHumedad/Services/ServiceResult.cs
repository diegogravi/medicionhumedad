using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicionHumedad.Services
{
    public class ServiceResult<T>
    {
        public T Data { get; set; }
        public string Msg { get; set; }
        public bool Success { get; set; }

    }
    public class ServiceResultList<T>
    {
        public List<T> Data { get; set; }
        public string Msg { get; set; }
        public bool Success { get; set; }

    }
}