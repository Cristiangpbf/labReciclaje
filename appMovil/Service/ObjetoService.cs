using LabReciclaje.Modelo;
using Newtonsoft.Json;
using LabReciclaje.Util;

namespace LabReciclaje.Service
{
    public class ObjetoService
    {
        private readonly Config _config = new Config();
        public async Task<List<ObjetoResponse>> GetObjetoAsync(int idCategoria)
        {
            var url = $"{_config.ApiUrl}objetoRest.php?idCategoria="+ idCategoria;
            var response = await _config.client.GetAsync(url);

            if (response != null && response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(responseString))
                {
                    var objeto = JsonConvert.DeserializeObject<List<ObjetoResponse>>(responseString);
                    return objeto;
                }
                else
                {
                    throw new Exception("No se encontraron categorías.");
                }
            }
            else
            {
                throw new Exception("Failed to get a valid response from the API.");
            }
        }
    }
}
