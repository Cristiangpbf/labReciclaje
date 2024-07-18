using LabReciclaje.Modelo;
using Newtonsoft.Json;
using LabReciclaje.Util;



namespace LabReciclaje.Service
{
    public class CategoriaService
    {
        private readonly Config _config = new Config();
        public async Task<List<CategoriaResponse>> GetCategoriasAsync()
        {
            var url = $"{_config.ApiUrl}categoriasRest.php"; 
            var response = await _config.client.GetAsync(url);

            if (response != null && response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(responseString))
                {
                    var categorias = JsonConvert.DeserializeObject<List<CategoriaResponse>>(responseString);
                    return categorias;
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
