using Vilash.Core.DTO;
namespace Vilash.Core.Interfaces;
public interface IPersonService
{
    Task<PersonDto?> GetAsync(Guid id);
    Task<IEnumerable<PersonDto>> GetAllAsync(int page = 1, int pageSize = 20);
    Task<Guid> CreateAsync(PersonDto dto);
    Task UpdateAsync(PersonDto dto);
    Task DeleteAsync(Guid id);
}
