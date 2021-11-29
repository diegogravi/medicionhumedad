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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioServiceAsync _UsuarioService;
        private IMapper _mapper;

        public UsuarioController(IUsuarioServiceAsync UsuarioService, IMapper mapper)
        {
            _UsuarioService = UsuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuario()
        {
            var Usuario = await _UsuarioService.GetAll();

            if (Usuario == null)
            {
                return NotFound();
            }

            return Ok(Usuario);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUsuarioById(int UsuarioId)
        {
            var Usuario = await _UsuarioService.Get(x => x.Id == UsuarioId);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Ok(Usuario);
        }
        [HttpGet]
        public async Task<IActionResult> GetUsuarioByGuid(string guid)
        {
            var Usuario = await _UsuarioService.Get(x => x.Guid == guid);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Ok(Usuario);
        }
        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioViewModel Usuario)
        {
            if (ModelState.IsValid)
            {
                var UsuarioId = await _UsuarioService.Add(Usuario);
                if (UsuarioId > 0)
                {
                    return Ok(UsuarioId);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> InactivateUsuarioByUsuarioId([FromBody]int UsuarioId)
        {
            if (ModelState.IsValid)
            {
                var Usuario = await _UsuarioService.GetById(UsuarioId);
                Usuario.Activo = false;
                var updated = await _UsuarioService.Update(Usuario);
                return Ok(updated);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> ActivateUsuarioByUsuarioId([FromBody]int UsuarioId)
        {
            if (ModelState.IsValid)
            {
                var Usuario = await _UsuarioService.GetById(UsuarioId);
                Usuario.Activo = true;
                var updated = await _UsuarioService.Update(Usuario);
                return Ok(updated);
            }

            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody] UsuarioViewModel Usuario)
        {
            bool result;

            if (ModelState.IsValid)
            {
                result = await _UsuarioService.Update(Usuario);

                if (result == false)
                {
                    return NotFound();
                }
            }

            return Ok();
        }
    }
}
