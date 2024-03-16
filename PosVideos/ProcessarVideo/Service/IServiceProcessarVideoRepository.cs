using PosVideosCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessarVideo.Service
{
    public interface IServiceProcessarVideoRepository
    {
        public Task ProcessarVideo(Video video);
        public Task MudarStatusVideo(Video video, StatusVideo statusVideo);
    }
}
