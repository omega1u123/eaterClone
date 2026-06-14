namespace EaterClone.Models;

public record SignInRequest
{
    public string Name { get; init; } = null!;
    public string Password { get; init; } = null!;
}