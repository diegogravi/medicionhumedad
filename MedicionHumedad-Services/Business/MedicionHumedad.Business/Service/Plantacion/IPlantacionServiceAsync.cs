using MedicionHumedad.Business.ViewModels;
using MedicionHumedad.Service;
using System;
using System.Collections.Generic;
using System.Text;
using MedicionHumedad.Data.Models;

namespace MedicionHumedad.Business.Service
{
    public interface IPlantacionServiceAsync : IServiceAsync<PlantacionViewModel, Plantacion>
    {
    }
}
