using PosVideosCore.Model;

namespace PosVideos.Queries;

public class VideoQuery
{
    public int? Id { get; set; }
    public string? Descritivo { get; set; }
    public string? Nome { get; set; }
    public StatusVideo? StatusVideo { get; set; }
    public DateTime? DataCriacao { get; set; }
}
