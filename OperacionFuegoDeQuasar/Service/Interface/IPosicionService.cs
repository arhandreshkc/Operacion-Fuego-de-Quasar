using OperacionFuegoDeQuasar.Model;
using System.Collections.Generic;

namespace OperacionFuegoDeQuasar.Service.Interface
{
    public interface IPosicionService
    {
        public PosicionModel GetLocation(IEnumerable<SateliteModel> satelites);
    }
}
