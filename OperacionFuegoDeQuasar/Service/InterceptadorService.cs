using OperacionFuegoDeQuasar.Model;
using OperacionFuegoDeQuasar.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OperacionFuegoDeQuasar.Service
{
    public class InterceptadorService : IInterceptadorService
    {
        private readonly IMensajeService _mensajeService;
        private readonly IPosicionService _posicionService;
        private readonly ISateliteService _sateliteService;

        public InterceptadorService(IMensajeService mensajeService, IPosicionService posicionService, ISateliteService sateliteService)
        {
            _mensajeService = mensajeService;
            _posicionService = posicionService;
            _sateliteService = sateliteService;
        }
        public RespuestaModel ObtenerTopSecretInfo(SateliteRootModel satelites)
        {
            try
            {
                return ObtenerRespuesta(satelites.Satelites.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception($"RESPONSE CODE: 404 {ex.Message}");
            }
        }
        public RespuestaModel ObtenerTopSecretInfo()
        {
            try
            {
                RespuestaModel respuesta =  ObtenerRespuesta(_sateliteService.GetSatelites().ToList());                
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception($"RESPONSE CODE: 404 {ex.Message}");
            }
            finally
            {
                _sateliteService.LimpiarSatelitesCargados();
            }
        }
        public string GuardarInfoSatelite(SateliteModel satelite, string sateliteName)
        {
            try
            {
                return _sateliteService.GuardarSatelite(satelite, sateliteName);
            }
            catch (Exception ex)
            {
                throw new Exception($"RESPONSE CODE: 404 {ex.Message}");
            }
        }
        private RespuestaModel ObtenerRespuesta(List<SateliteModel> satelites)
        {
            try
            {
                RespuestaModel respuesta = new RespuestaModel();

                respuesta.PosicionObjetivo = _posicionService.GetLocation(satelites);
                respuesta.MensajeOculto = _mensajeService.GetMessage(satelites);

                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
