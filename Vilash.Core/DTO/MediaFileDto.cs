using Vilash.Core.Enums;
namespace Vilash.Core.DTO;
public record MediaFileDto(Guid Id, string FileName, string Url, MediaType Type);
