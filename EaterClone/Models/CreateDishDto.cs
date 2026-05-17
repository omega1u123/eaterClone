namespace EaterClone.Models;

public record CreateDishDto
{
    public string Name { get; init; } = null!;
    public int Weight { get; init; }
    public List<Guid> ProductsId { get; init; } = null!;
    public string PictureUrl { get; init; } = null!;
    public Guid UserId { get; init; } 
}