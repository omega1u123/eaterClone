namespace EaterClone.Models;

public record SignUpRequest
{
    public string Name { get; init; } = null!;
    public string Password { get; init; } = null!;
}