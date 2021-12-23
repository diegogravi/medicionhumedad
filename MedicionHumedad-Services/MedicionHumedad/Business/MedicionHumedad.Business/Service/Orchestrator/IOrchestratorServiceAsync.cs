using MedicionHumedad.Business.ViewModels;
using MedicionHumedad.Service;
using System;
using System.Collections.Generic;
using System.Text;
using MedicionHumedad.Data.Models;
using System.Threading.Tasks;

namespace MedicionHumedad.Business.Service
{
    public interface IOrchestratorServiceAsync : IServiceAsync<MedicionViewModel, Medicion>
    {
        Task<List<LineChartData>> GetPredictionData(string dateStart, string hourStart, int repetitions);
        Task<List<LineChartData>> GetMedicionesData(int lecturas, int plantacionId);
    }
}
