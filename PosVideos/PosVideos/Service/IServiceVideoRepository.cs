using Microsoft.EntityFrameworkCore;
using PosVideosCore.Model;
using System.Linq.Expressions;

namespace PosVideos.Service;

public interface IServiceVideoRepository
{
    public Task<IEnumerable<Video?>> ListVideos(Expression<Func<Video, bool>>? filter = null);
}

public class ServiceVideoRepository : IServiceVideoRepository
{
    private readonly PosVideoContext _context;

    public ServiceVideoRepository(PosVideoContext context)
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
}