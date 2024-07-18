using LabReciclaje.Modelo;
using Newtonsoft.Json;
using LabReciclaje.Util;


namespace LabReciclaje.Service
{
    public class CentroService
    {
        private readonly Config _config = new Config();
        public async Task<List<CentroResponse>> GetCentrosAsync()
        {
            var url = $"{_config.ApiUrl}centroRest.php";
            var response = await _config.client.GetAsync(url);

            if (response != null && response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(responseString))
                {
                    var centro = JsonConvert.DeserializeObject<List<CentroResponse>>(responseString);
                    return centro;
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
