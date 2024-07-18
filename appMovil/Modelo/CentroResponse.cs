using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabReciclaje.Modelo
{
    public class CentroResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("direccion")]
        public string Direccion { get; set; }

        [JsonProperty("latitud")]
        public string Latitud { get; set; }

        [JsonProperty("longitud")]
        public string Longitud { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }
        [JsonProperty("imagen")]
        public string Imagen { get; set; }
        [JsonProperty("estado")]
        public int Estado { get; set; }
    }
}
