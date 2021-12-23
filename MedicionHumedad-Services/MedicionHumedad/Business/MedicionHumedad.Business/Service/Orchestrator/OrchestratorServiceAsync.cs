using AutoMapper;
using MedicionHumedad.Business.ViewModels;
using MedicionHumedad.Data.Models;
using MedicionHumedad.Data.UnitofWork;
using MedicionHumedad.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace MedicionHumedad.Business.Service
{
    public class OrchestratorServiceAsync : GenericServiceAsync<MedicionViewModel, Medicion>, IOrchestratorServiceAsync
    {
        public OrchestratorServiceAsync(
            IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<LineChartData>> GetPredictionData(string dateStart, string hourStart, int repetitions)
        {
            var httpClient = new HttpClient();
            var dateStartParam = DateTime.Parse(dateStart);//.ToString("yyyy-MM-dd");
            var url = "http://127.0.0.1:5000/get_custom_humidity";
            HumidityPrediction prediction = new HumidityPrediction();
            List<LineChartData> data = new List<LineChartData>();
            string dateToUseOnPrediction = string.Empty;

            for (int i = 0; i < repetitions; i++)
            {
                dateToUseOnPrediction = dateStartParam.AddDays(i).ToString("yyyy-MM-dd");
                var paramsToPass = new { date = dateToUseOnPrediction, hour = hourStart };
                prediction = new HumidityPrediction();

                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Post, url))
                using (var response = await httpClient.PostAsync(url, paramsToPass.AsJson()))
                {
                    var content = await response.Content.ReadAsStringAsync();
                    prediction = JsonConvert.DeserializeObject<HumidityPrediction>(content);
                    data.Add(new LineChartData(dateToUseOnPrediction + " " + hourStart, Math.Round(prediction.humidity, 2)));
                }

            }
            //data.Add(new LineChartData("2021-12-23 12:11", Math.Round(42.5995182901965, 2)));
            //data.Add(new LineChartData("2021-12-24 12:11", Math.Round(42.45119831512799, 2)));
            //data.Add(new LineChartData("2021-12-25 12:11", Math.Round(42.45119831512799, 2)));
            //data.Add(new LineChartData("2021-12-26 12:11", Math.Round(40.538495283949835, 2)));
            //data.Add(new LineChartData("2021-12-27 12:11", Math.Round(40.05835617939913, 2)));
            //data.Add(new LineChartData("2021-12-28 12:11", Math.Round(39.18315448107612, 2)));
            //data.Add(new LineChartData("2021-12-29 12:11", Math.Round(42.88477836663142, 2)));
            //data.Add(new LineChartData("2021-12-30 12:11", Math.Round(42.5995182901965, 2)));
            //data.Add(new LineChartData("2021-12-31 12:11", Math.Round(42.45119831512799, 2)));

            return data;
        }
        public async Task<List<LineChartData>> GetMedicionesData(int lecturas, int plantacionId)
        {
            //Get all sensor ids from the plantacion
            var mediciones = (from m in await _unitOfWork.GetRepositoryAsync<Medicion>().GetAll()
                      join s in await _unitOfWork.GetRepositoryAsync<Sensor>().GetAll() 
                      on m.SensorId equals s.Id
                      where s.PlantacionId == plantacionId
                      orderby m.Fecha descending
                      select m).Take(lecturas);


            List < LineChartData > data = new List<LineChartData>();

            foreach (var item in mediciones)
            {
                data.Add(new LineChartData(item.Fecha.ToString("MM/dd/yyyy HH:mm"), Convert.ToDouble(item.Porcentaje)));
            }
            //data.Add(new LineChartData("2021-12-23 12:11", Math.Round(42.5995182901965, 2)));
            //data.Add(new LineChartData("2021-12-24 12:11", Math.Round(42.45119831512799, 2)));
            //data.Add(new LineChartData("2021-12-25 12:11", Math.Round(42.45119831512799, 2)));
            //data.Add(new LineChartData("2021-12-26 12:11", Math.Round(40.538495283949835, 2)));
            //data.Add(new LineChartData("2021-12-27 12:11", Math.Round(40.05835617939913, 2)));
            //data.Add(new LineChartData("2021-12-28 12:11", Math.Round(39.18315448107612, 2)));
            //data.Add(new LineChartData("2021-12-29 12:11", Math.Round(42.88477836663142, 2)));
            //data.Add(new LineChartData("2021-12-30 12:11", Math.Round(42.5995182901965, 2)));
            //data.Add(new LineChartData("2021-12-31 12:11", Math.Round(42.45119831512799, 2)));

            return data;
        }
    }
}
