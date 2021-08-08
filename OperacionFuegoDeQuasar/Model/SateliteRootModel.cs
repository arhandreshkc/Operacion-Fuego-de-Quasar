using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OperacionFuegoDeQuasar.Model
{
    public class SateliteRootModel
    {
        [JsonPropertyName("satellites")]
        public List<SateliteModel> Satelites { get; set; }
    }
}
