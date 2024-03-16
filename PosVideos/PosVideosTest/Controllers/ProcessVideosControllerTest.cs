using FluentAssertions;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using PosVideos.Controllers;
using PosVideos.Queries;
using PosVideos.Service;
using PosVideosCore.Model;
using System.Linq.Expressions;

namespace PosVideosTest.Controllers;

public class ProcessVideosControllerTest
{
    private readonly ProcessVideosController _controller;
    const string NOMEFILAPROCESSARVIDEO = "NomeFileProcessarVideo";
    //private readonly IServiceVideoRepository _serviceVideoRepository = Substitute.For<IServiceVideoRepository>();
    private readonly IBus _bus;
    private readonly IConfiguration _configuration;

    public ProcessVideosControllerTest()
    {
        _controller = new ProcessVideosController(_serviceVideoRepository, _bus, _configuration);
    }

    [Fact]
    public async Task ShouldReturnSuccessWhenProcessarVideoIsSuccessful()
    {
        var serviceVideoRepository = Mock.Of<IServiceVideoRepository>();

        var videoProcessQuery = new VideoProcessQuery
        {
            CaminhoVideo = "c:/teste",
            NomeVideo = "videoTest.mp4"
        };

        Mock.Get(serviceVideoRepository)
            .Setup(v => v.ProcessarVideos(It.IsAny<Expression<Func<Video, bool>>>()))
            .ReturnsAsync();

        var listVideosController = new ListVideosController(serviceVideoRepository);

        var result =  await listVideosController.ProcessarVideos(videoProcessQuery);

        var objectResult = Assert.IsType<OkObjectResult>(result.Result);

        objectResult.StatusCode.Should().Be(200);
        objectResult.Value.Should().NotBeNull();
    }

    //[Fact]
    //public void AlugarLivroTest_ShouldReturnSuccessWhenAluguelIsSuccessful()
    //{
    //    // Arrange
    //    var videoProcessQuery = new VideoProcessQuery
    //    {
    //        CaminhoVideo = "c:/teste",
    //        NomeVideo = "videoTest.mp4"
    //    };

    //    _parametros.BuscarNomeFila(NOMEFILAPROCESSARVIDEO).Returns("TestFila");
    //    var endpoint = Substitute.For<ISendEndpoint>();
    //    _parametros.MontarEndpoint("TestFila").Returns(endpoint);

    //    // Act
    //    var result = _controller.ProcessarVideos(videoProcessQuery).Result;

    //    // Assert
    //    var okResult = Assert.IsType<OkObjectResult>(result);
    //    Assert.Equal(200, okResult.StatusCode);
    //    _serviceVideoRepository.ProcessarVideos(requisicaoEsperada, endpoint);
    //}
}