using MedicionHumedad.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicionHumedad.Services
{
    public class PlantacionService : BaseService
    {
        private const string getAllEdificios = "Plantacion/GetAllPlantaciones";
        private const string getPlantacionById = "Plantacion/GetPlantacionById";
        private const string crearPlantacion = "Plantacion/CrearPlantacion";
        private const string editarPlantacion = "Plantacion/EditarPlantacion";
        private const string borrarPlantacionByPlantacionId = "Plantacion/BorrarPlantacionByPlantacionId";

        public bool BorrarPlantacionByPlantacionId(int plantacionId)
        {
            bool queryResult;
            try
            {
                var request = new RestRequest(borrarPlantacionByPlantacionId, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(plantacionId);

                //client.Execute(request);

                queryResult = client.Execute<bool>(request).Data;
            }
            catch (Exception ex)
            {
                return false;
            }

            return queryResult;

        }

        public List<PlantacionViewModel> GetAllPlantaciones()
        {
            List<PlantacionViewModel> queryResult = new List<PlantacionViewModel>();
            try
            {
                var request = new RestRequest(getAllEdificios, Method.GET);

                queryResult = client.Execute<List<PlantacionViewModel>>(request).Data;
            }
            catch(Exception ex)
            {
                return null;
            }

            return queryResult;
        }
        public PlantacionViewModel GetPlantacionById(int plantacionId)
        {
            PlantacionViewModel queryResult = new PlantacionViewModel();
            try
            {
                var request = new RestRequest(getPlantacionById, Method.GET);

                request.AddParameter("plantacionId", plantacionId);
                queryResult = client.Execute<PlantacionViewModel>(request).Data;
            }
            catch (Exception ex)
            {
                return null;
            }

            return queryResult;
        }

        public int CrearPlantacion(PlantacionViewModel plantacion)
        {
            int queryResult;
            try
            {
                var request = new RestRequest(crearPlantacion, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(plantacion);

                //client.Execute(request);

                queryResult = client.Execute<int>(request).Data;
            }
            catch (Exception ex)
            {
                return 0;
            }

            return queryResult;
        }
        public int EditarPlantacion(PlantacionViewModel plantacion)
        {
            int queryResult;
            try
            {
                var request = new RestRequest(editarPlantacion, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(plantacion);

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