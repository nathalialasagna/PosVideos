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
            var videoPath = @$"C:\TEMP\{video.Nome}";

            var outputFolder = _configuration.GetSection("VideoProcessing")["PastaSaidaImagens"];

            Directory.CreateDirectory(outputFolder);

            var videoInfo = await FFProbe.AnalyseAsync(videoPath);
            var duration = videoInfo.Duration;

            var interval = TimeSpan.FromSeconds(20);

            for (var currentTime = TimeSpan.Zero; currentTime < duration; currentTime += interval)
            {
                var outputPath = Path.Combine(outputFolder, $"frame_at_{currentTime.TotalSeconds}.jpg");
                FFMpeg.Snapshot(videoPath, outputPath, new Size(1920, 1080), currentTime);
            }
            //string destinationZipFilePath = _configuration.GetSection("VideoProcessing")["PastaSaidaImagensZip"];
            Guid idVideo = Guid.NewGuid();

            ZipFile.CreateFromDirectory(_configuration.GetSection("VideoProcessing")["PastaSaidaImagensZip"], $"{video.Nome}_{idVideo.ToString()}.zip");


            //ZipFile.CreateFromDirectory(outputFolder, destinationZipFilePath);

        }

        public async Task<int> Inserir(Video video)
        {
            await _context.Video.AddAsync(video);
            return await _context.SaveChangesAsync();
        }

        public async Task MudarStatusVideo(Video video, StatusVideo statusVideo)
        {
            var entity = await _context.Video.Where(x => x.Id == video.Id).FirstOrDefaultAsync();

            if (entity != null)
            {
                entity.StatusVideo = statusVideo;

                _context.SaveChangesAsync();
            }
        }
    }
}
