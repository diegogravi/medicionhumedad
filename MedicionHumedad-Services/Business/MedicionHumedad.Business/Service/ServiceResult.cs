using System;
using System.Collections.Generic;
using System.Text;

namespace MedicionHumedad.Business.Service
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
