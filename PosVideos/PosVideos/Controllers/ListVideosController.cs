using Microsoft.AspNetCore.Mvc;
using PosVideos.Dto;
using PosVideos.Queries;
using PosVideos.Service;
using PosVideosCore.Model;

namespace PosVideos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListVideosController : ControllerBase
    {
        private readonly IServiceVideoRepository _serviceVideoRepository;

        public ListVideosController(IServiceVideoRepository serviceVideoRepository)
        {
            _serviceVideoRepository = serviceVideoRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<VideoDto>>> ListVideos([FromQuery] VideoQuery? videoQuery)
        {
            //IEnumerable<Video?> videos;

                    var videos = new List<Video>
                    {
                   new() {
                       Id = 1,
                       Descritivo = "video Teste",
                       Nome = "Teste",
                       CaminhoVideo = "c:/teste",
                       CaminhoVideoZip = "c:/teste",
                       StatusVideo = StatusVideo.Processado,
                       DataCriacao = DateTime.Now,
                       DataFimProcessamento = DateTime.Now
                   },
                   new() {
                       Id = 2,
                       Descritivo = "video Teste",
                       Nome = "Teste",
                       CaminhoVideo = "c:/teste",
                       CaminhoVideoZip = "c:/teste",
                       StatusVideo = StatusVideo.Processado,
                       DataCriacao = DateTime.Now,
                       DataFimProcessamento = DateTime.Now

                   },
                    new() {
                       Id = 3,
                       Descritivo = "video Teste",
                       Nome = "Teste",
                       CaminhoVideo = "c:/teste",
                       CaminhoVideoZip = "c:/teste",
                       StatusVideo = StatusVideo.Processado,
                       DataCriacao = DateTime.Now,
                       DataFimProcessamento = DateTime.Now

                    },
                    };
            //if (videoQuery == null)
            //{
            //    videos = await _serviceVideoRepository.ListVideos();
            //}
            //else {
            //    videos = await _serviceVideoRepository.ListVideos(v => v.Id == videoQuery.Id 
            //                                                || v.Descritivo == videoQuery.Descritivo
            //                                                || v.Nome == videoQuery.Nome
            //                                                || v.StatusVideo == videoQuery.StatusVideo
            //                                                || v.DataCriacao == videoQuery.DataCriacao);
            //}

            if (!videos.Any()) return NotFound();

            return Ok(videos);
        }
    }
}
