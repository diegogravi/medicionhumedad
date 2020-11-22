using OfficeHoteling.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeHoteling.Services
{
    public class EdificioService : BaseService
    {
        private const string getAllEdificios = "Edificio/GetAllEdificios";

        public List<EdificioViewModel> GetAllEdificios()
        {
            List<EdificioViewModel> queryResult = new List<EdificioViewModel>();
            try
            {
                var request = new RestRequest(getAllEdificios, Method.GET);

                queryResult = client.Execute<List<EdificioViewModel>>(request).Data;
            }
            catch(Exception ex)
            {
                return null;
            }

            return queryResult;
        }
    }
}