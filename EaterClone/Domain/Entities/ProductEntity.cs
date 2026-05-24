namespace EaterClone.Domain.Entities;

public class ProductEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    public float Proteins { get; set; } 
    public float Fats { get; set; }
    public float Carbs { get; set; }
    
    public List<DishEntity> Dishes { get; set; } = null!;
}