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
    public class PlantacionController : ControllerBase
    {
        private IPlantacionServiceAsync _PlantacionService;
        private ISensorServiceAsync _SensorService;
        private IMapper _mapper;

        public PlantacionController(IPlantacionServiceAsync PlantacionService, ISensorServiceAsync SensorService, IMapper mapper)
        {
            _PlantacionService = PlantacionService;
            _SensorService = SensorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlantaciones()
        {
            var mediciones = await _PlantacionService.GetAll();

            if (mediciones == null)
            {
                return NotFound();
            }

            return Ok(mediciones);
        }
        [HttpGet]
        public async Task<IActionResult> GetPlantacionById(int plantacionId)
        {
            var plantacion = await _PlantacionService.GetById(plantacionId);

            if (plantacion == null)
            {
                return NotFound();
            }

            return Ok(plantacion);
        }
        [HttpPost]
        public async Task<IActionResult> CrearPlantacion([FromBody]PlantacionViewModel plantacion)
        {
            var sensorAgregado = await _PlantacionService.Add(plantacion);
            return Ok(sensorAgregado);
        }
        [HttpPost]
        public async Task<IActionResult> EditarPlantacion([FromBody]PlantacionViewModel plantacion)
        {
            var sensorEditado = await _PlantacionService.Update(plantacion);

            return Ok(sensorEditado);
        }

        [HttpPost]
        public async Task<IActionResult> BorrarPlantacionByPlantacionId([FromBody]int plantacionId)
        {
            var sensorList = await _SensorService.Get(x => x.PlantacionId == plantacionId);

            if(sensorList != null && sensorList.Count() > 0)
            {
                return Ok(false);
            }
            var medicionBorrada = await _PlantacionService.Remove(plantacionId);

            return Ok(medicionBorrada);
        }
    }
}
