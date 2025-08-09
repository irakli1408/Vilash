using Vilash.Core.DTO;
namespace Vilash.Core.Interfaces;
public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync();
}
