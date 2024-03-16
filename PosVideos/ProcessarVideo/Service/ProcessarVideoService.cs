using FFMpegCore;
using Microsoft.EntityFrameworkCore;
using PosVideos.Models;
using PosVideosCore.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessarVideo.Service
{
    public class ProcessarVideoService : IProcessarVideoService
    {
        private readonly ProcessarVideoContext _context;
        private readonly IConfiguration _configuration;

        public ProcessarVideoService(ProcessarVideoContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }



        public async Task ProcessarVideo(Video video)
        {
            try
            {
                MudarStatusVideo(video, StatusVideo.EmProcessamento);

                Directory.CreateDirectory(video.CaminhoVideo);

                var videoInfo = FFProbe.Analyse(video.Nome);
                var duration = videoInfo.Duration;

                var interval = TimeSpan.FromSeconds(20);

                for (var currentTime = TimeSpan.Zero; currentTime < duration; currentTime += interval)
                {
                    var outputPath = Path.Combine(_configuration.GetSection("VideoProcessing")["PastaSaidaImagens"], $"frame_at_{currentTime.TotalSeconds}.jpg");
                    FFMpeg.Snapshot(video.Nome, outputPath, new Size(1920, 1080), currentTime);
                }
                Guid idVideo = Guid.NewGuid();

                ZipFile.CreateFromDirectory(_configuration.GetSection("VideoProcessing")["PastaSaidaImagensZip"], $"{video.Nome}_{idVideo.ToString()}.zip");

                MudarStatusVideo(video, StatusVideo.Processado);
            }
            catch(Exception ex)
            {
                MudarStatusVideo(video, StatusVideo.Erro);
            }

        }

        public async Task<int> Inserir(Video video)
        {
            await _context.Video.AddAsync(video);
            return await _context.SaveChangesAsync();
        }

        public async Task MudarStatusVideo(Video video, StatusVideo statusVideo)
        {
            var entity = await _context.Video.Where(x => x.Id == video.Id).FirstOrDefaultAsync();

            entity.StatusVideo = statusVideo;

            _context.SaveChangesAsync();
        }
    }
}
