using LabReciclaje.Modelo;
using Newtonsoft.Json;
using LabReciclaje.Util;


namespace LabReciclaje.Service
{
    public class NoticiaService
    {
        private readonly Config _config = new Config();
        public async Task<List<NoticiaResponse>> GetNoticiaAsync()
        {
            var url = $"{_config.ApiUrl}noticiaRest.php";
            var response = await _config.client.GetAsync(url);

            if (response != null && response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(responseString))
                {
                    var noticia = JsonConvert.DeserializeObject<List<NoticiaResponse>>(responseString);
                    return noticia;
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
