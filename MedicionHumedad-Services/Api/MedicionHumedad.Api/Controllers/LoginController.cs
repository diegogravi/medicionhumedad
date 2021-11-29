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
    public class LoginController : ControllerBase
    {
        private IUsuarioServiceAsync _UsuarioService;
        private IMapper _mapper;

        public LoginController(IUsuarioServiceAsync UsuarioService, IMapper mapper)
        {
            _UsuarioService = UsuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string guid, string password)
        {
            ServiceResult<UsuarioViewModel> result = new ServiceResult<UsuarioViewModel>();
            var Usuario = await _UsuarioService.GetFirstOrDefault(x => x.Guid == guid);

            if (Usuario == null)
            {
                result.Msg = "El nombre de GUID no es valido, intentelo de nuevo";
            }
            else
            {
                if(Usuario.Password != password)
                {
                    result.Msg = "El password es incorrecto, intentelo de nuevo";
                }
                else
                {
                    if (!Usuario.Activo)
                    {
                        result.Msg = "El usuario esta desactivado, contactese con el administrador";
                    }
                    else
                    {
                        result.Data = Usuario;
                        result.Success = true;
                    }
                }
            }

            return Ok(result);
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
    }
}
