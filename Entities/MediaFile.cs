using Vilash.Core.Enums;
namespace Vilash.Core.Entities;
public class MediaFile
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = default!;
    public string Url { get; set; } = default!;
    public MediaType Type { get; set; }
    public TimeSpan? Duration { get; set; }
    public Guid? PersonId { get; set; }
}
