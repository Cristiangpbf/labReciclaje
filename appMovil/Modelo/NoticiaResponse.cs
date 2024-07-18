using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabReciclaje.Modelo
{
    public class NoticiaResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("titulo")]
        public string Titulo { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("fecha")]
        public DateOnly Fecha { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

    }
}
