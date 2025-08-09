using Vilash.Core.Enums;
namespace Vilash.Core.Entities;
public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = default!;
    public UserRole Role { get; set; } = UserRole.Viewer;
}
