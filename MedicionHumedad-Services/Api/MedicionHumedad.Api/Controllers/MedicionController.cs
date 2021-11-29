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
            var staff = await _MedicionService.GetAll();

            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }
        
    }
}
