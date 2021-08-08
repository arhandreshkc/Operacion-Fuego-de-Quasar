using OperacionFuegoDeQuasar.Model;
using System.Collections.Generic;

namespace OperacionFuegoDeQuasar.Service.Interface
{
    public interface IInterceptadorService
    {
        public RespuestaModel ObtenerTopSecretInfo(SateliteRootModel satelites);
        public RespuestaModel ObtenerTopSecretInfo();
        public string GuardarInfoSatelite(SateliteModel satelite, string sateliteName);
    }
}
