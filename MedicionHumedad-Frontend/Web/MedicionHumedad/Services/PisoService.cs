using MedicionHumedad.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicionHumedad.Services
{
    public class PisoService : BaseService
    {
        private const string getAllPisosByEdificioId = "Piso/GetAllPisosByEdificioId";

        public List<PisoViewModel> GetAllPisosByEdificioId(int edificioId)
        {
            List<PisoViewModel> queryResult = new List<PisoViewModel>();
            try
            {
                var request = new RestRequest(getAllPisosByEdificioId, Method.GET);

                request.AddParameter("edificioId", edificioId);
                queryResult = client.Execute<List<PisoViewModel>>(request).Data;
            }
            catch(Exception ex)
            {
                return null;
            }

            return queryResult;
        }
    }
}