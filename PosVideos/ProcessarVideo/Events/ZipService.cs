using MassTransit;
using PosVideosCore.Model;
using ProcessarVideo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessarVideo.Events
{
    public class ZipService : IConsumer<Video>
    {
        private readonly IProcessarVideoService _serviceProcessarVideoRepository;

        public ZipService(IProcessarVideoService serviceProcessarVideoRepository)
        {
            _serviceProcessarVideoRepository = serviceProcessarVideoRepository;
        }

        public async Task Consume(ConsumeContext<Video> context)
        {
            await ProcessarVideo(new Video() { CaminhoVideo = context.Message.CaminhoVideo, DataCriacao = context.Message.DataCriacao, 
                Descritivo = context.Message.Descritivo, StatusVideo = context.Message.StatusVideo});
        }

        public async Task ProcessarVideo(Video video)
        {
            var entity = _serviceProcessarVideoRepository.Inserir(video);
            _serviceProcessarVideoRepository.ProcessarVideo(video);
        }
    }
}
