namespace Vilash.Core.Entities;
public class Person
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public string? Bio { get; set; }
    public ICollection<MediaFile> Media { get; set; } = new List<MediaFile>();
    public ICollection<Category> Categories { get; set; } = new List<Category>();
}
