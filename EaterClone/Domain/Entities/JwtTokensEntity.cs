namespace EaterClone.Domain.Entities;

public class JwtTokensEntity : BaseEntity
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
}