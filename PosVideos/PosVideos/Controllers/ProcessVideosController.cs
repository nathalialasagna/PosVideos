using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PosVideos.Queries;
using PosVideos.Service;

namespace PosVideos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessVideosController : ControllerBase
    {
        private readonly IServiceVideoRepository _serviceVideoRepository;
        private readonly IBus _bus;
        const string MASSTRANSIT = "MassTransit";
        const string QUEUE = "queue";
        private readonly IConfiguration _configuration;

        public ProcessVideosController(IServiceVideoRepository serviceVideoRepository, IBus bus, IConfiguration configuration)
        {
            _serviceVideoRepository = serviceVideoRepository;
            _bus = bus;
            _configuration = configuration;

        }

        [HttpPost]
        public async Task<IActionResult> ProcessarVideo([FromQuery] VideoProcessQuery? videoProcessQuery)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();

                }

                await _serviceVideoRepository.ProcessarVideo(videoProcessQuery);

                var nomeFila = _configuration.GetSection(MASSTRANSIT)["nomeFila"] ?? string.Empty;
                await _bus.GetSendEndpoint(new Uri($"{QUEUE}:{nomeFila}"));

                return Ok();
            }
            catch (RabbitMqAddressException exRabbit)
            {
                return StatusCode(400, $"Erro ao enviar a solicitação: {exRabbit.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Falha interna do servidor!");
            }
        }
    }
}
