using LabReciclaje.Modelo;
using Newtonsoft.Json;
using LabReciclaje.Util;
using System.Text;


namespace LabReciclaje.Service
{
    public class UsuarioService
    {
        private readonly Config _config = new Config();

        public async Task<UsuarioResponse> LoginAsync(string usuario, string password)
        {
            var url = $"{_config.ApiUrl}loginRest.php?usuario={usuario}&password={password}";

            var response = await _config.client.GetAsync(url);

            if (response != null && response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(responseString))
                {
                    var usuarioResponse = JsonConvert.DeserializeObject<UsuarioResponse>(responseString);
                    return usuarioResponse;
                }
                else
                {
                    throw new Exception("Usuario no encontrado...");
                }
            }
            else
            {
                throw new Exception("Failed to get a valid response from the API.");
            }
        }
        

        public async Task<bool> ValidarUsuarioAsync(string usuario)
        {
            try
            {
                var url = $"{_config.ApiUrl}loginRest.php?usuario={usuario}";
                var response = await _config.client.GetAsync(url);
                var responseString = await response.Content.ReadAsStringAsync();
                var usuarioResponse = JsonConvert.DeserializeObject<UsuarioResponse>(responseString);
                if (usuarioResponse != null && usuarioResponse.Usuario == usuario)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> InsertarUsuarioAsync(UsuarioResponse usuario)
        {
            try
            {
                var url = $"{_config.ApiUrl}loginRest.php";

                var json = JsonConvert.SerializeObject(new
                {
                    nombres = usuario.Nombres,
                    apellidos = usuario.Apellidos,
                    email = usuario.Email,
                    usuario = usuario.Usuario,
                    password = usuario.Password
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _config.client.PostAsync(url, content);

                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode && !string.IsNullOrWhiteSpace(responseString) && responseString != "false")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
                return false;
            }
        }

        public async Task<bool> ActualizarUsuarioAsync(int idUsuario, string email, string? password)
        {
            try
            { 
                var url = $"{_config.ApiUrl}loginRest.php?idUsuario={idUsuario}&email={email}";


                if (!string.IsNullOrEmpty(password))
                {
                    url+=$"&password={password}";
                }

                HttpResponseMessage response = await _config.client.PutAsync(url, null);


                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }


    }
}
