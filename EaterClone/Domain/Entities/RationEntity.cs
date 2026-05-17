namespace EaterClone.Domain.Entities;

public class RationEntity : BaseEntity
{
    public DateOnly Date { get; set; }
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = null!;
    public List<Guid> Meals { get; set; } = null!;
}