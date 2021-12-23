using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicionHumedad.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using MedicionHumedad.Business.Service;
    using MedicionHumedad.Business.ViewModels;
    using MedicionHumedad.ViewModels;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private ISensorServiceAsync _SensorService;
        private IMapper _mapper;

        public SensorController(ISensorServiceAsync SensorService, IMapper mapper)
        {
            _SensorService = SensorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSensores()
        {
            //var sensores = await _SensorService.GetAll();
            var sensores = await _SensorService.GetSensoresConMasDetalles();

            if (sensores == null)
            {
                return NotFound();
            }

            return Ok(sensores);
        }
        [HttpGet]
        public async Task<IActionResult> GetSensorById(int sensorId)
        {
            var sensor = await _SensorService.GetById(sensorId);

            if (sensor == null)
            {
                return NotFound();
            }

            return Ok(sensor);
        }

        [HttpGet]
        public async Task<IActionResult> GetSensorByPlantacionId(int plantacionId)
        {
            var sensorList = await _SensorService.Get(x=> x.PlantacionId == plantacionId && x.Activo == true);

            if (sensorList == null)
            {
                sensorList = new List<SensorViewModel>();
            }

            return Ok(sensorList);
        }
        [HttpPost]
        public async Task<IActionResult> CrearSensor([FromBody]SensorViewModel sensor)
        {
            var sensorAgregado = await _SensorService.Add(sensor);
            return Ok(sensorAgregado);
        }
        [HttpPost]
        public async Task<IActionResult> EditarSensor([FromBody]SensorViewModel sensor)
        {
            var sensorEditado = await _SensorService.Update(sensor);

            return Ok(sensorEditado);
        }
        [HttpPost]
        public async Task<IActionResult> BorrarSensorBySensorId([FromBody]int SensorId)
        {
            var sensor = await _SensorService.GetById(SensorId);
            sensor.Activo = false;
            var sensorEditado = await _SensorService.Update(sensor);

            return Ok(sensorEditado);
        }
        [HttpPost]
        public async Task<IActionResult> ActivarSensorBySensorId([FromBody]int SensorId)
        {
            var sensor = await _SensorService.GetById(SensorId);
            sensor.Activo = true;
            var sensorEditado = await _SensorService.Update(sensor);

            return Ok(sensorEditado);
        }
    }
}
