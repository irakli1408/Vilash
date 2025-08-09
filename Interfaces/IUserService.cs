using Vilash.Core.DTO;
namespace Vilash.Core.Interfaces;
public interface IUserService
{
    Task<UserDto?> GetAsync(Guid id);
}
