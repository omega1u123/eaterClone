namespace EaterClone.Domain.Entities;

public class MealEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    public Guid RationId { get; set; }
    public RationEntity Ration { get; set; } = null!;
    public List<DishEntity> Dishes { get; set; } = null!;
}