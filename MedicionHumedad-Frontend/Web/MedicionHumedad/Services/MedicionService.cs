using MedicionHumedad.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicionHumedad.Services
{
    public class MedicionService : BaseService
    {
        private const string getMedicionById = "Medicion/GetMedicionById";
        private const string getMedicionesByUsuarioId = "Medicion/GetMedicionesByUsuarioId";
        private const string crearMedicion = "Medicion/CrearMedicion"; 
        private const string editarMedicion = "Medicion/EditarMedicion"; 
        private const string borrarMedicionByMedicionId = "Medicion/BorrarMedicionByMedicionId";

        public bool BorrarMedicionByMedicionId(int medicionId)
        {
            bool queryResult;
            try
            {
                var request = new RestRequest(borrarMedicionByMedicionId, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(medicionId);

                //client.Execute(request);

                queryResult = client.Execute<bool>(request).Data;
            }
            catch (Exception ex)
            {
                return false;
            }

            return queryResult;

        }

        public MedicionViewModel GetMedicionById(int medicionId)
        {
            MedicionViewModel queryResult = new MedicionViewModel();
            try
            {
                var request = new RestRequest(getMedicionById, Method.GET);

                request.AddParameter("medicionId", medicionId);
                queryResult = client.Execute<MedicionViewModel>(request).Data;
            }
            catch(Exception ex)
            {
                return null;
            }

            return queryResult;
        }
        public List<MedicionViewModel> GetMedicionesByUsuarioId(int UsuarioId)
        {
            List<MedicionViewModel> queryResult = new List<MedicionViewModel>();
            try
            {
                var request = new RestRequest(getMedicionesByUsuarioId, Method.GET);

                request.AddParameter("usuarioId", UsuarioId);
                queryResult = client.Execute<List<MedicionViewModel>>(request).Data;
            }
            catch (Exception ex)
            {
                return null;
            }

            return queryResult;
        }
        public int CrearMedicion(MedicionViewModel medicion)
        {
            int queryResult;
            try
            {
                var request = new RestRequest(crearMedicion, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(medicion);

                //client.Execute(request);

                queryResult = client.Execute<int>(request).Data;
            }
            catch (Exception ex)
            {
                return 0;
            }

            return queryResult;
        }
        public int EditarMedicion(MedicionViewModel medicion)
        {
            int queryResult;
            try
            {
                var request = new RestRequest(editarMedicion, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(medicion);

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