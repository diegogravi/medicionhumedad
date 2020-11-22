using OfficeHoteling.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeHoteling.Services
{
    public class EspacioService : BaseService
    {
        private const string getEspaciosDisponiblesByPisoId = "Espacio/GetEspaciosDisponiblesByPisoId";

        public List<EspacioViewModel> GetEspaciosDisponiblesByPisoId(int pisoId, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<EspacioViewModel> queryResult = new List<EspacioViewModel>();
            try
            {
                var request = new RestRequest(getEspaciosDisponiblesByPisoId, Method.GET);

                request.AddParameter("pisoId", pisoId);
                request.AddParameter("fechaDesde", fechaDesde);
                request.AddParameter("fechaHasta", fechaHasta);
                queryResult = client.Execute<List<EspacioViewModel>>(request).Data;
            }
            catch(Exception ex)
            {
                return null;
            }

            return queryResult;
        }
    }
}