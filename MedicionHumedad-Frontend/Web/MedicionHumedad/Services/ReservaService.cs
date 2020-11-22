using OfficeHoteling.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeHoteling.Services
{
    public class ReservaService : BaseService
    {
        private const string getReservaById = "Reservas/GetReservaById";
        private const string getReservasByStaffId = "Reservas/GetReservasByStaffId";
        private const string crearReserva = "Reservas/CrearReserva"; 
        private const string inactivateReservaByReservaId = "Reservas/InactivateReservaByReservaId";

        public bool InactivateReservaByReservaId(int reservaId)
        {
            bool queryResult;
            try
            {
                var request = new RestRequest(inactivateReservaByReservaId, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(reservaId);

                //client.Execute(request);

                queryResult = client.Execute<bool>(request).Data;
            }
            catch (Exception ex)
            {
                return false;
            }

            return queryResult;

        }

        public ReservaViewModel GetReservaById(int reservaId)
        {
            ReservaViewModel queryResult = new ReservaViewModel();
            try
            {
                var request = new RestRequest(getReservaById, Method.GET);

                request.AddParameter("reservaId", reservaId);
                queryResult = client.Execute<ReservaViewModel>(request).Data;
            }
            catch(Exception ex)
            {
                return null;
            }

            return queryResult;
        }
        public List<ReservaViewModel> GetReservasByStaffId(int staffId)
        {
            List<ReservaViewModel> queryResult = new List<ReservaViewModel>();
            try
            {
                var request = new RestRequest(getReservasByStaffId, Method.GET);

                request.AddParameter("staffId", staffId);
                queryResult = client.Execute<List<ReservaViewModel>>(request).Data;
            }
            catch (Exception ex)
            {
                return null;
            }

            return queryResult;
        }
        public int CrearReserva(ReservaViewModel reserva)
        {
            int queryResult;
            try
            {
                var request = new RestRequest(crearReserva, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(reserva);

                //client.Execute(request);

                queryResult = client.Execute<int>(request).Data;
            }
            catch (Exception ex)
            {
                return 0;
            }

            return queryResult;
        }
    }
}