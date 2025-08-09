using Vilash.Core.DTO;
namespace Vilash.Core.Interfaces;
public interface IMediaFileService
{
    Task<MediaFileDto?> GetAsync(Guid id);
    Task<IEnumerable<MediaFileDto>> GetByPersonAsync(Guid personId);
    Task<Guid> CreateAsync(MediaFileDto dto);
    Task DeleteAsync(Guid id);
}
