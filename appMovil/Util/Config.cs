using Newtonsoft.Json;


namespace LabReciclaje.Util
{
    public class Config
    {
        public string ApiUrl { get; set; } = "https://laboratoriodereciclaje.org/LabReciclajeWebService/";
        public HttpClient client { get; } = new HttpClient();

    }
    public class ErrorResponse
    {
        [JsonProperty("MessageError")]
        public string MessageError { get; set; }
    }

}
