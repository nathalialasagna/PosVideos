using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PosVideos.Queries;
using PosVideos.Service;
using PosVideosCore;
using PosVideosCore.Interfaces.Parameters;
using PosVideosCore.Model;

namespace PosVideos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessVideosController : ControllerBase
    {
        private readonly IParametros _parametros;
        private readonly IServiceVideoRepository _serviceVideoRepository;
        private readonly IBus _bus;
        const string NOMEFILAPOSVIDEOS = "NomeFilaPosVideos";
        const string MASSTRANSIT = "MassTransit";
        const string QUEUE = "queue";
        private readonly IConfiguration _configuration;

        public ProcessVideosController(IServiceVideoRepository serviceVideoRepository, IBus bus, IConfiguration configuration, IParametros parametros)
        {
            _serviceVideoRepository = serviceVideoRepository;
            _bus = bus;
            _configuration = configuration;
            _parametros = parametros;

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

                await SendSolicitacao(videoProcessQuery);

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

        /// <summary>
        /// Sends a solicitation using RabbitMQ.
        /// </summary>
        /// <param name="videoProcessQuery">The solicitation object to send. </param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="RabbitMqAddressException">Thrown when there is an error with the RabbitMQ address.</exception>
        /// <exception cref="Exception">Thrown when there is an unexpected error.</exception>
        private async Task SendSolicitacao(VideoProcessQuery? videoProcessQuery)
        {
            var objRequisicao = Video.Map(videoProcessQuery);
            var nomeFila = _parametros.BuscarNomeFila(NOMEFILAPOSVIDEOS);
            var endpoint = await _parametros.MontarEndpoint(nomeFila);
            await _serviceVideoRepository.ProcessarVideo(objRequisicao, endpoint);
        }
    }
}
