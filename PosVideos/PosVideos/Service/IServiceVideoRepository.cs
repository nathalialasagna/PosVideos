using MassTransit;
using Microsoft.EntityFrameworkCore;
using PosVideos.Models;
using PosVideos.Queries;
using PosVideosCore;
using PosVideosCore.Model;
using System.Linq.Expressions;

namespace PosVideos.Service;

public interface IServiceVideoRepository
{
    public Task<IEnumerable<Video?>> ListVideos(Expression<Func<Video, bool>>? filter = null);
    Task ProcessarVideo(Video video, ISendEndpoint endpoint);
}

public class ServiceVideoRepository : IServiceVideoRepository
{
    private readonly PVContext _context;

    public ServiceVideoRepository(PVContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Video?>> ListVideos(Expression<Func<Video, bool>>? filter = null)
    {
        IQueryable<Video> query = _context.Video;

        if (filter != null)
        {
            query = query.Where(filter);
        }
;
        return await query.ToListAsync();
    }

    public async Task ProcessarVideo(Video video, ISendEndpoint endpoint)
    {
        await endpoint.Send(video);
    }
}