using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabReciclaje.Modelo
{
    public class ObjetoResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("idCategoria")]
        public string IdCategoria { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }
    }
}
