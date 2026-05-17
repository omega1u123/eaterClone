namespace EaterClone.Domain.Entities;

public class DishEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    public int Weight { get; set; }
    public List<ProductEntity> Products { get; set; } = null!;
    public string PictureUrl { get; set; } = null!;
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = null!;
}