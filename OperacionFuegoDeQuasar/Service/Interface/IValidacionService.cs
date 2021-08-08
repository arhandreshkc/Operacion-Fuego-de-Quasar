using OperacionFuegoDeQuasar.Model;
using System.Collections.Generic;

namespace OperacionFuegoDeQuasar.Service.Interface
{
    public interface IValidacionService
    {
        public void ValidaSatelites(IEnumerable<SateliteModel> satelites, IEnumerable<SateliteModel> satelitesConocidos);
        public void ValidaSatelite(SateliteModel satelite, IEnumerable<SateliteModel> satelitesConocidos);
    }
}
