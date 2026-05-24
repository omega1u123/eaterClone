namespace EaterClone.Domain.Entities;

public class UserTokensEntity : BaseEntity
{
    public string AccessToken { get; init; } = null!;
    public string RefreshToken { get; init; } = null!;
}