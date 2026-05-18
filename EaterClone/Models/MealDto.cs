namespace EaterClone.Models;

public record MealDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public Guid RationId { get; init; }
    public List<Guid> DishIds { get; init; } = null!;
    
}