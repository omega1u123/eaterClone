namespace EaterClone.Models;

public record SignUpResponse
{
    public Guid UserId { get; init; }
    public string Name { get; init; } = null!;
    public string AccessToken { get; init; } = null!;
    public string RefreshToken { get; init; } = null!;
}