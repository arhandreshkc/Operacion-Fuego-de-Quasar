using OperacionFuegoDeQuasar.Model;
using System.Collections.Generic;

namespace OperacionFuegoDeQuasar.Service.Interface
{
    public interface ISateliteService
    {
        public string GuardarSatelite(SateliteModel satelite, string sateliteName);
        public IEnumerable<SateliteModel> GetSatelitesConocidos();
        public IEnumerable<SateliteModel> GetSatelites();
        public void LimpiarSatelitesCargados();
    }
}
