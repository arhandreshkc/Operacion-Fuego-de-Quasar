using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace OperacionFuegoDeQuasar.Model
{
    public class SateliteModel
    {
        [JsonPropertyName("name")]
        [JsonProperty(Required = Required.AllowNull)]
        public string Nombre { get; set; }

        [JsonPropertyName("distance")]
        public float? Distancia { get; set; }

        [JsonPropertyName("message")]
        public string[] Mensaje { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public PosicionModel Posicion { get; set; }
    }
}
