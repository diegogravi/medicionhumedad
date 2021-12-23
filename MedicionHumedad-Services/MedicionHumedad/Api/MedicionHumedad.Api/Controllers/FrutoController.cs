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
    public class FrutoController : ControllerBase
    {
        private IFrutoServiceAsync _FrutoService;
        private IMapper _mapper;

        public FrutoController(IFrutoServiceAsync FrutoService, IMapper mapper)
        {
            _FrutoService = FrutoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFrutos()
        {
            var frutos = await _FrutoService.GetAll();

            if (frutos == null)
            {
                return NotFound();
            }

            return Ok(frutos);
        }
        [HttpGet]
        public async Task<IActionResult> GetFrutoById(int frutoId)
        {
            var fruto = await _FrutoService.GetById(frutoId);

            if (fruto == null)
            {
                return NotFound();
            }

            return Ok(fruto);
        }

    }
}
