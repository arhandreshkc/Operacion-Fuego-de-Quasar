using Microsoft.AspNetCore.Mvc;
using OperacionFuegoDeQuasar.Model;
using OperacionFuegoDeQuasar.Service.Interface;
using System;
using System.Collections.Generic;

namespace OperacionFuegoDeQuasar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterceptadorController : ControllerBase
    {

        private readonly IInterceptadorService _interceptadorService;
        public InterceptadorController(IInterceptadorService interceptadorService)
        {
            _interceptadorService = interceptadorService;
        }
        [HttpPost("~/Topsecret")]
        public ActionResult<RespuestaModel> Topsecret(SateliteRootModel satelites)
        {
            try
            {
                return Ok(_interceptadorService.ObtenerTopSecretInfo(satelites));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("~/Topsecret_Split/{satellite_name}")]
        public ActionResult<string> Topsecret_Split(SateliteModel satelite, string satellite_name)
        {
            try
            {
                return Ok(_interceptadorService.GuardarInfoSatelite(satelite, satellite_name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("~/Topsecret_Split")]
        public ActionResult<RespuestaModel> Topsecret_Split()
        {
            try
            {
                return Ok(_interceptadorService.ObtenerTopSecretInfo());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
