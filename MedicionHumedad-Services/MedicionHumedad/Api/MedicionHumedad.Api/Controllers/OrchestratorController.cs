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
    public class OrchestratorController : ControllerBase
    {
        private IOrchestratorServiceAsync _OrchestratorService;
        private IMapper _mapper;

        public OrchestratorController(IOrchestratorServiceAsync OrchestratorService, IMapper mapper)
        {
            _OrchestratorService = OrchestratorService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetPredictionData(string dateStart, string hourStart, int repetitions)
        {
            var lineChartDatas = await _OrchestratorService.GetPredictionData(dateStart, hourStart, repetitions);

            if (lineChartDatas == null)
            {
                return NotFound();
            }

            return Ok(lineChartDatas);
        }
        [HttpGet]
        public async Task<IActionResult> GetMedicionesData(int lecturas, int plantacionId)
        {
            var lineChartDatas = await _OrchestratorService.GetMedicionesData(lecturas, plantacionId);

            if (lineChartDatas == null)
            {
                return NotFound();
            }

            return Ok(lineChartDatas);
        }
    }
}
