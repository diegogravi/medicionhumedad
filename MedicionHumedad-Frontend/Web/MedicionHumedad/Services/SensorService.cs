using MedicionHumedad.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicionHumedad.Services
{
    public class SensorService : BaseService
    {
        private const string getAllSensores = "Sensor/GetAllSensores";
        private const string getSensorById = "Sensor/GetSensorByPlantacionId";
        private const string crearSensor = "Sensor/CrearSensor";
        private const string editarSensor = "Sensor/EditarSensor";
        private const string borrarSensorBySensorId = "Sensor/borrarSensorBySensorId";
        private const string activarSensorBySensorId = "Sensor/ActivarSensorBySensorId";

        public List<SensorViewModel> GetAllSensores()
        {
            List<SensorViewModel> queryResult = new List<SensorViewModel>();
            try
            {
                var request = new RestRequest(getAllSensores, Method.GET);

                queryResult = client.Execute<List<SensorViewModel>>(request).Data;
            }
            catch(Exception ex)
            {
                return null;
            }

            return queryResult;
        }
        public SensorViewModel GetSensorById(int sensorId)
        {
            SensorViewModel queryResult = new SensorViewModel();
            try
            {
                var request = new RestRequest(getSensorById, Method.GET);

                request.AddParameter("sensorId", sensorId);
                queryResult = client.Execute<SensorViewModel>(request).Data;
            }
            catch (Exception ex)
            {
                return null;
            }

            return queryResult;
        }
        public List<SensorViewModel> GetSensorByPlantacionId(int plantacionId)
        {
            List<SensorViewModel> queryResult = new List<SensorViewModel>();
            try
            {
                var request = new RestRequest(getSensorById, Method.GET);

                request.AddParameter("plantacionId", plantacionId);
                queryResult = client.Execute<List<SensorViewModel>>(request).Data;
            }
            catch (Exception ex)
            {
                return null;
            }

            return queryResult;
        }
        public int CrearSensor(SensorViewModel sensor)
        {
            int queryResult;
            try
            {
                var request = new RestRequest(crearSensor, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(sensor);

                //client.Execute(request);

                queryResult = client.Execute<int>(request).Data;
            }
            catch (Exception ex)
            {
                return 0;
            }

            return queryResult;
        }
        public int EditarSensor(SensorViewModel sensor)
        {
            int queryResult;
            try
            {
                var request = new RestRequest(editarSensor, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(sensor);

                //client.Execute(request);

                queryResult = client.Execute<int>(request).Data;
            }
            catch (Exception ex)
            {
                return 0;
            }

            return queryResult;
        }
        public bool BorrarSensorBySensorId(int SensorId)
        {
            bool queryResult;
            try
            {
                var request = new RestRequest(borrarSensorBySensorId, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(SensorId);

                //client.Execute(request);

                queryResult = client.Execute<bool>(request).Data;
            }
            catch (Exception ex)
            {
                return false;
            }

            return queryResult;

        }
        public bool ActivarSensorBySensorId(int SensorId)
        {
            bool queryResult;
            try
            {
                var request = new RestRequest(activarSensorBySensorId, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(SensorId);

                //client.Execute(request);

                queryResult = client.Execute<bool>(request).Data;
            }
            catch (Exception ex)
            {
                return false;
            }

            return queryResult;

        }
    }
}