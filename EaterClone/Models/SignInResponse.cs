namespace EaterClone.Models;

public record SignInResponse
{
    public Guid UserId { get; init; }
    public string Name { get; init; } = null!;
    public string AccessToken { get; init; } = null!;
    public string RefreshToken { get; init; } = null!;
}