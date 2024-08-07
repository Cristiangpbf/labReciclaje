using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using LabReciclaje.Service;
using LabReciclaje.Modelo;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestLabReciclaje.Service
{
    public class NoticiaServiceTests
    {
        private Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private HttpClient _httpClient;
        private NoticiaService _noticiaService;
        private Config _config;

        [SetUp]
        public void SetUp()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object);
            _config = new Config { client = _httpClient, ApiUrl = "https://example.com/" };
            _noticiaService = new NoticiaService(_config);
        }

        [Test]
        public async Task GetNoticiaAsync_ReturnsNoticias_WhenApiResponseIsValid()
        {
            // Arrange
            var noticias = new List<NoticiaResponse>
            {
                new NoticiaResponse { Id = 1, Titulo = "Noticia 1", Contenido = "Contenido 1" },
                new NoticiaResponse { Id = 2, Titulo = "Noticia 2", Contenido = "Contenido 2" }
            };
            var jsonResponse = JsonConvert.SerializeObject(noticias);
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonResponse)
            };

            _httpMessageHandlerMock
                .Setup(m => m.Send(It.IsAny<HttpRequestMessage>()))
                .Returns(httpResponseMessage);

            // Act
            var result = await _noticiaService.GetNoticiaAsync();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Noticia 1", result[0].Titulo);
        }
    }
}
