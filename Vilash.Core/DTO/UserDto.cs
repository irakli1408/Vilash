using Vilash.Core.Enums;
namespace Vilash.Core.DTO;
public record UserDto(Guid Id, string Username, UserRole Role);
