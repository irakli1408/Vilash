namespace Vilash.Core.Entities;
public class Category
{
    public Guid Id { get; set; }
    public string Key { get; set; } = default!;
    public string? Name { get; set; }
}
