using MedicionHumedad.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicionHumedad.Services
{
    public class FrutoService : BaseService
    {
        private const string getAllFrutos = "Fruto/GetAllFrutos";
        private const string getFrutoById = "Fruto/GetFrutoById";

        public List<FrutoViewModel> GetAllFrutos()
        {
            List<FrutoViewModel> queryResult = new List<FrutoViewModel>();
            try
            {
                var request = new RestRequest(getAllFrutos, Method.GET);

                queryResult = client.Execute<List<FrutoViewModel>>(request).Data;
            }
            catch(Exception ex)
            {
                return null;
            }

            return queryResult;
        }
        public FrutoViewModel GetFrutoById(int frutoId)
        {
            FrutoViewModel queryResult = new FrutoViewModel();
            try
            {
                var request = new RestRequest(getFrutoById, Method.GET);

                request.AddParameter("frutoId", frutoId);
                queryResult = client.Execute<FrutoViewModel>(request).Data;
            }
            catch (Exception ex)
            {
                return null;
            }

            return queryResult;
        }
    }
}