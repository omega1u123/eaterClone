namespace EaterClone.Models;

public record RationDto
{
    public Guid Id { get; init; }
    public DateOnly  Date { get; init; }
    public List<Guid> MealIds { get; init; } = null!;
}