using LabReciclaje.Service;
using FluentAssertions;

namespace TestProject1.Service
{
    public class NoticiaServiceTests
    {
        NoticiaService noticiaService;
        [Fact]
        public async void GetNoticiaAsyncTest()
        {            
            //Arrange
            noticiaService = new NoticiaService();

            //Act
            var noticia = await noticiaService.GetNoticiaAsync();

            //Assert
            noticia.Should().NotBeNull();
        }
    }
}
