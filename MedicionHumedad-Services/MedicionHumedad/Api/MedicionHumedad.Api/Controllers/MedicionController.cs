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
    using System.Threading;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MedicionController : ControllerBase
    {
        private IMedicionServiceAsync _MedicionService;
        private IMapper _mapper;

        public MedicionController(IMedicionServiceAsync MedicionService, IMapper mapper)
        {
            _MedicionService = MedicionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicion()
        {
            var mediciones = await _MedicionService.GetAll();

            if (mediciones == null)
            {
                return NotFound();
            }

            return Ok(mediciones);
        }
        [HttpGet]
        public async Task<IActionResult> GetMedicionesByUsuarioId(int usuarioId)
        {
            var mediciones = await _MedicionService.GetMedicionesConMasDetallesByUsuarioId(usuarioId);

            if (mediciones == null)
            {
                return NotFound();
            }

            return Ok(mediciones);
        }
        [HttpGet]
        public async Task<IActionResult> GetMedicionById(int medicionId)
        {
            var mediciones = await _MedicionService.GetById(medicionId);

            if (mediciones == null)
            {
                return NotFound();
            }

            return Ok(mediciones);
        }

        [HttpPost]
        public async Task<IActionResult> CrearMedicion([FromBody]MedicionViewModel medicion)
        {
            var medicionAgregada = await _MedicionService.Add(medicion);

            return Ok(medicionAgregada);
        }

        [HttpPost]
        public async Task<IActionResult> BorrarMedicionByMedicionId([FromBody]int medicionId)
        {
            var medicionBorrada = await _MedicionService.Remove(medicionId);

            return Ok(medicionBorrada);
        }

    }
}
