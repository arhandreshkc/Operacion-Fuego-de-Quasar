using OperacionFuegoDeQuasar.Model;
using System.Collections.Generic;

namespace OperacionFuegoDeQuasar.Service.Interface
{
    public interface IMensajeService
    {
        public string GetMessage(IEnumerable<SateliteModel> satelites);
    }
}
