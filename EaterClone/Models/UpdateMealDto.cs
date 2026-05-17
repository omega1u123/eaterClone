namespace EaterClone.Models;

public record UpdateMealDto
{
    public Guid MealId { get; init; }
    public Guid DishId { get; init; }
}