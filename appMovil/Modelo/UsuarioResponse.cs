using Newtonsoft.Json;

namespace LabReciclaje.Modelo
{
    public class UsuarioResponse
    {
        [JsonProperty("idUsuario")]
        public int IdUsuario { get; set; }

        [JsonProperty("idCuenta")]
        public int IdCuenta { get; set; }

        [JsonProperty("privilegio")]
        public int Privilegio { get; set; }

        [JsonProperty("usuario")]
        public string Usuario { get; set; }

        [JsonProperty("estadoUsuario")]
        public int EstadoUsuario { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("nombres")]
        public string Nombres { get; set; }

        [JsonProperty("apellidos")]
        public string Apellidos { get; set; }

        [JsonProperty("estadoCuenta")]
        public int EstadoCuenta { get; set; }

        [JsonProperty("puntos")]
        public string Puntos { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }

        public string Password { get; set; }
    }
}
