using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PosVideos.Controllers;
using PosVideos.Queries;
using PosVideos.Service;
using PosVideosCore.Model;
using System.Linq.Expressions;


namespace PosVideosTest.Controllers;

public class ListVideosControllerTest
{
    [Fact]
    public async Task ShouldReturnSuccessWhenListarIsSuccessful()
    {
        var serviceVideoRepository = Mock.Of<IServiceVideoRepository>();

        var videoQuery = new VideoQuery
        {
            Descritivo = "video Teste"
        };

        var videos = new List<Video>
        {
           new() {
               Id = 1,
               Descritivo = "video Teste",
               CaminhoVideo = "c:/teste",
               CaminhoVideoZip = "c:/teste",
               StatusVideo = StatusVideo.Processado,
               DataCriacao = DateTime.Now,
               DataFimProcessamento = DateTime.Now
           },
           new() {
               Id = 2,
               Descritivo = "video Teste",
               CaminhoVideo = "c:/teste",
               CaminhoVideoZip = "c:/teste",
               StatusVideo = StatusVideo.Processado,
               DataCriacao = DateTime.Now,
               DataFimProcessamento = DateTime.Now

           },
        };

        Mock.Get(serviceVideoRepository)
            .Setup(v => v.ListVideos(It.IsAny<Expression<Func<Video, bool>>>()))
            .ReturnsAsync(videos);

        var listVideosController = new ListVideosController(serviceVideoRepository);

        var result =  await listVideosController.ListVideos(videoQuery);

        var objectResult = Assert.IsType<OkObjectResult>(result.Result);

        objectResult.StatusCode.Should().Be(200);
        objectResult.Value.Should().NotBeNull();
    }

    [Fact]
    public async Task ShouldReturnNotFoundWhenListarNotFoundVideos()
    {
        var serviceVideoRepository = Mock.Of<IServiceVideoRepository>();

        var videoQuery = new VideoQuery
        {
            Descritivo = "video Teste"
        };
        IEnumerable<Video> videos = [];

        Mock.Get(serviceVideoRepository)
            .Setup(v => v.ListVideos(It.IsAny<Expression<Func<Video, bool>>>()))
            .ReturnsAsync(videos);

        var listVideosController = new ListVideosController(serviceVideoRepository);

        var result = await listVideosController.ListVideos(videoQuery);

        var objectResult = Assert.IsType<NotFoundResult>(result.Result);

        objectResult.StatusCode.Should().Be(404);
        result.Value.Should().BeNull();
    }
}