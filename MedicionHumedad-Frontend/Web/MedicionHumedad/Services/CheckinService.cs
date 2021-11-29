using MedicionHumedad.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicionHumedad.Services
{
    public class CheckinService : BaseService
    {
        private const string checkinByReservaIdd = "Checkin/CheckinByReservaId";
        private const string getCurrentCheckinByUsuarioId = "Checkin/GetCurrentCheckinByUsuarioId";
        private const string inactivateCheckinByCheckinId = "Checkin/InactivateCheckinByCheckinId";

        public bool InactivateCheckinByCheckinId(int checkinId)
        {
            bool queryResult;
            try
            {
                var request = new RestRequest(inactivateCheckinByCheckinId, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(checkinId);

                //client.Execute(request);

                queryResult = client.Execute<bool>(request).Data;
            }
            catch (Exception ex)
            {
                return false;
            }

            return queryResult;

        }

        public int CheckinByReservaId(int reservaId)
        {
            int queryResult;
            try
            {
                var request = new RestRequest(checkinByReservaIdd, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(reservaId);

                //client.Execute(request);

                queryResult = client.Execute<int>(request).Data;
            }
            catch (Exception ex)
            {
                return 0;
            }

            return queryResult;
        }
        public CheckinViewModel GetCurrentCheckinByUsuarioId(int UsuarioId)
        {
            CheckinViewModel queryResult = new CheckinViewModel();
            try
            {
                var request = new RestRequest(getCurrentCheckinByUsuarioId, Method.GET);

                request.AddParameter("UsuarioId", UsuarioId);
                queryResult = client.Execute<CheckinViewModel>(request).Data;
            }
            catch (Exception ex)
            {
                return null;
            }

            return queryResult;
        }
    }
}